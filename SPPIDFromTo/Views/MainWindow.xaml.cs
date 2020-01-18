using Oracle.ManagedDataAccess.Client;
using SPPIDFromTo.DataAccess;
using SPPIDFromTo.Models;
using System;
using System.Collections.Generic;
using System.Windows;

namespace SPPIDFromTo.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OracleDataAccess oracleDataAccess;

        public MainWindow()
        {
            InitializeComponent();

            oracleDataAccess = new OracleDataAccess("DB_HOST", "DB_PORT", "DB_SID", "db_UID", "db_PWD");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (!oracleDataAccess.ConnectToDatabase()) return;

            //string query = "select * from sppidplantpid.t_piperun pr where pr.sp_id='AABBED9AEA5E40AAA7E29B1040B7DB50'";
            //string query = "select * from sppidplantpid.t_piperun";
            string query = "select " +
                            "pr.sp_id, pl.itemtag, pr.piperuntype, pr.piperunclass, pr.nominaldiameter, " +
                            "pr.operfluidcode, pr.pipingmaterialsclass, pr.tagsequenceno, pr.insulpurpose, pr.htracemedium, " +
                            "con.sp_id, con.sp_connectitem1id, con.sp_connectitem2id " +
                            "from sppidplantpid.t_piperun pr " +
                            "inner join SPPIDPLANTPID.t_plantitem pl on pl.sp_id = pr.sp_id " +
                            "inner join SPPIDPLANTPID.t_representation rep on rep.sp_modelitemid = pr.sp_id " +
                            "inner join SPPIDPLANTPID.t_connector con on con.sp_id = rep.sp_id";

            using (OracleDataReader reader = oracleDataAccess.ExecuteQuery(query))
            {
                if (reader == null || reader.HasRows == false) return;

                List<PipeRun> pipeRuns = new List<PipeRun>();
                //List<Connector> connectors = new List<Connector>();
                //List<PipeLine> pipeLines = new List<PipeLine>();

                while (reader.Read())
                {
                    PipeRun pipeRun = new PipeRun();

                    pipeRun.SPID = reader[0].ToString();
                    pipeRun.ItemTag = reader[1].ToString();
                    pipeRun.Type = Convert.ToInt32(reader[2]);
                    pipeRun.Class = Convert.ToInt32(reader[3]);

                    pipeRun.NominalDiameter = reader[4].ToString();
                    pipeRun.Fluid = reader[5].ToString();
                    pipeRun.PipeMaterialsClass = reader[6].ToString();
                    pipeRun.SeqNumber = reader[7].ToString();
                    pipeRun.Insulation = reader[8].ToString();
                    pipeRun.HeatTrace = reader[9].ToString();

                    pipeRuns.Add(pipeRun);
                }

                if (pipeRuns.Count > 0)
                {
                    dgPiperuns.DataContext = pipeRuns;
                    dgPiperuns.ItemsSource = pipeRuns;
                }
            }
        }

        private void btnConnector_Click(object sender, RoutedEventArgs e)
        {

            if (!oracleDataAccess.ConnectToDatabase()) return;

            string query = "select " +
                            "con.sp_id, pr.sp_id, con.sp_connectitem1id, con.sp_connectitem2id, " +
                            "(select rep.filename from SPPIDPLANTPID.t_representation rep where rep.sp_id = con.sp_connectitem1id) as End1ItemSymbol, " +
                            "(select rep.filename from SPPIDPLANTPID.t_representation rep where rep.sp_id = con.sp_connectitem2id) as End2ItemSymbol " +
                            "from sppidplantpid.t_piperun pr " +
                            "inner join SPPIDPLANTPID.t_plantitem pl on pl.sp_id = pr.sp_id " +
                            "inner join SPPIDPLANTPID.t_representation rep on rep.sp_modelitemid = pr.sp_id " +
                            "inner join SPPIDPLANTPID.t_connector con on con.sp_id = rep.sp_id";

            using (OracleDataReader reader = oracleDataAccess.ExecuteQuery(query))
            {
                if (reader == null || reader.HasRows == false) return;

                List<Connector> connectors = new List<Connector>();
                while (reader.Read())
                {
                    Connector connector = new Connector();
                    connector.SPID = reader[0].ToString();
                    connector.PipeRun_SPID = reader[1].ToString();
                    connector.SP_ConnectedItem1ID = reader[2].ToString();
                    connector.SP_ConnectedItem2ID = reader[3].ToString();
                    connector.End1ItemSymbol = reader[4].ToString();
                    connector.End2ItemSymbol = reader[5].ToString();

                    connectors.Add(connector);

                }

                if (connectors.Count > 0)
                {
                    dgConnectors.DataContext = connectors;
                    dgConnectors.ItemsSource = connectors;
                }
            }

        }
    }
}
