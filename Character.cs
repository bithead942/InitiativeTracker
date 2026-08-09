using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace InitiativeTracker
{
    public class Character
    {
        public int iTotalPlayers = 0;
        public bool bDMMode = false;
        public int iCurrentInitiative = 1;
        public int iMaxCharacters = 15;
        public struct Attributes
        {
            public bool Visible;
            public string Initiative;
            public string Name;
            public bool Lock;
            public string InitRoll;
            public string ACLow;
            public string ACHigh;
            public string HP;
            public string ConditionA;
            public string ConditionB;
        }
        public Attributes[] Attribs = new Attributes[20];
        
        public Character()  //Initialization
        {

        }

        public void saveValues()
        {
            string[] strFile = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };

            if (bDMMode == true)
                strFile[0] = "1";
            else
                strFile[0] = "0";
            strFile[0] += ",";
            strFile[0] += iCurrentInitiative.ToString();

            for (int x=0; x < 20; x++)
            {
                strFile[x + 1] = Attribs[x].Initiative;
                strFile[x + 1] += ",";
                strFile[x + 1] += Attribs[x].Name;
                strFile[x + 1] += ",";
                if (Attribs[x].Lock == true)
                    strFile[x + 1] += "1";
                else
                    strFile[x + 1] += "0";
                strFile[x + 1] += ",";
                if (Attribs[x].Visible == true)
                    strFile[x + 1] += "1";
                else
                    strFile[x + 1] += "0";
                strFile[x + 1] += ",";
                strFile[x + 1] += Attribs[x].InitRoll;
                strFile[x + 1] += ",";
                strFile[x + 1] += Attribs[x].ACLow;
                strFile[x + 1] += ",";
                strFile[x + 1] += Attribs[x].ACHigh;
                strFile[x + 1] += ",";
                strFile[x + 1] += Attribs[x].HP;
                strFile[x + 1] += ",";
                strFile[x + 1] += Attribs[x].ConditionA;
                strFile[x + 1] += ",";
                strFile[x + 1] += Attribs[x].ConditionB;
            }

            try
            {
                File.WriteAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"InitiativeTracker.txt"), strFile);
            }
            catch (Exception ex)
            {
                //handle file error
            }
        }

        public void loadValues_Blank()
        {
            Attribs[0].Visible = false;
            Attribs[0].Initiative = "1";
            Attribs[0].Name = "";
            Attribs[0].Lock = false;
            Attribs[0].InitRoll = "0";
            Attribs[0].ACLow = "0";
            Attribs[0].ACHigh = "0";
            Attribs[0].HP = "0";
            Attribs[0].ConditionA = "Normal";
            Attribs[0].ConditionB = "";

            Attribs[1].Visible = false;
            Attribs[1].Initiative = "2";
            Attribs[1].Name = "";
            Attribs[1].Lock = false;
            Attribs[1].InitRoll = "0";
            Attribs[1].ACLow = "0";
            Attribs[1].ACHigh = "0";
            Attribs[1].HP = "0";
            Attribs[1].ConditionA = "Normal";
            Attribs[1].ConditionB = "";

            Attribs[2].Visible = false;
            Attribs[2].Initiative = "3";
            Attribs[2].Name = "";
            Attribs[2].Lock = false;
            Attribs[2].InitRoll = "0";
            Attribs[2].ACLow = "0";
            Attribs[2].ACHigh = "0";
            Attribs[2].HP = "0";
            Attribs[2].ConditionA = "Normal";
            Attribs[2].ConditionB = "";

            Attribs[3].Visible = false;
            Attribs[3].Initiative = "4";
            Attribs[3].Name = "";
            Attribs[3].Lock = false;
            Attribs[3].InitRoll = "0";
            Attribs[3].ACLow = "0";
            Attribs[3].ACHigh = "0";
            Attribs[3].HP = "0";
            Attribs[3].ConditionA = "Normal";
            Attribs[3].ConditionB = "";

            Attribs[4].Visible = false;
            Attribs[4].Initiative = "5";
            Attribs[4].Name = "";
            Attribs[4].Lock = false;
            Attribs[4].InitRoll = "0";
            Attribs[4].ACLow = "0";
            Attribs[4].ACHigh = "0";
            Attribs[4].HP = "0";
            Attribs[4].ConditionA = "Normal";
            Attribs[4].ConditionB = "";

            Attribs[5].Visible = false;
            Attribs[5].Initiative = "6";
            Attribs[5].Name = "";
            Attribs[5].Lock = false;
            Attribs[5].InitRoll = "0";
            Attribs[5].ACLow = "0";
            Attribs[5].ACHigh = "0";
            Attribs[5].HP = "0";
            Attribs[5].ConditionA = "Normal";
            Attribs[5].ConditionB = "";

            Attribs[6].Visible = false;
            Attribs[6].Initiative = "7";
            Attribs[6].Name = "";
            Attribs[6].Lock = false;
            Attribs[6].InitRoll = "0";
            Attribs[6].ACLow = "0";
            Attribs[6].ACHigh = "0";
            Attribs[6].HP = "0";
            Attribs[6].ConditionA = "Normal";
            Attribs[6].ConditionB = "";

            Attribs[7].Visible = false;
            Attribs[7].Initiative = "8";
            Attribs[7].Name = "";
            Attribs[7].Lock = false;
            Attribs[7].InitRoll = "0";
            Attribs[7].ACLow = "0";
            Attribs[7].ACHigh = "0";
            Attribs[7].HP = "0";
            Attribs[7].ConditionA = "Normal";
            Attribs[7].ConditionB = "";

            Attribs[8].Visible = false;
            Attribs[8].Initiative = "9";
            Attribs[8].Name = "";
            Attribs[8].Lock = false;
            Attribs[8].InitRoll = "0";
            Attribs[8].ACLow = "0";
            Attribs[8].ACHigh = "0";
            Attribs[8].HP = "0";
            Attribs[8].ConditionA = "Normal";
            Attribs[8].ConditionB = "";

            Attribs[9].Visible = false;
            Attribs[9].Initiative = "10";
            Attribs[9].Name = "";
            Attribs[9].Lock = false;
            Attribs[9].InitRoll = "0";
            Attribs[9].ACLow = "0";
            Attribs[9].ACHigh = "0";
            Attribs[9].HP = "0";
            Attribs[9].ConditionA = "Normal";
            Attribs[9].ConditionB = "";

            Attribs[10].Visible = false;
            Attribs[10].Initiative = "11";
            Attribs[10].Name = "";
            Attribs[10].Lock = false;
            Attribs[10].InitRoll = "0";
            Attribs[10].ACLow = "0";
            Attribs[10].ACHigh = "0";
            Attribs[10].HP = "0";
            Attribs[10].ConditionA = "Normal";
            Attribs[10].ConditionB = "";

            Attribs[11].Visible = false;
            Attribs[11].Initiative = "12";
            Attribs[11].Name = "";
            Attribs[11].Lock = false;
            Attribs[11].InitRoll = "0";
            Attribs[11].ACLow = "0";
            Attribs[11].ACHigh = "0";
            Attribs[11].HP = "0";
            Attribs[11].ConditionA = "Normal";
            Attribs[11].ConditionB = "";

            Attribs[12].Visible = false;
            Attribs[12].Initiative = "13";
            Attribs[12].Name = "";
            Attribs[12].Lock = false;
            Attribs[12].InitRoll = "0";
            Attribs[12].ACLow = "0";
            Attribs[12].ACHigh = "0";
            Attribs[12].HP = "0";
            Attribs[12].ConditionA = "Normal";
            Attribs[12].ConditionB = "";

            Attribs[13].Visible = false;
            Attribs[13].Initiative = "14";
            Attribs[13].Name = "";
            Attribs[13].Lock = false;
            Attribs[13].InitRoll = "0";
            Attribs[13].ACLow = "0";
            Attribs[13].ACHigh = "0";
            Attribs[13].HP = "0";
            Attribs[13].ConditionA = "Normal";
            Attribs[13].ConditionB = "";

            Attribs[14].Visible = false;
            Attribs[14].Initiative = "15";
            Attribs[14].Name = "";
            Attribs[14].Lock = false;
            Attribs[14].InitRoll = "0";
            Attribs[14].ACLow = "0";
            Attribs[14].ACHigh = "0";
            Attribs[14].HP = "0";
            Attribs[14].ConditionA = "Normal";
            Attribs[14].ConditionB = "";

            Attribs[15].Visible = false;
            Attribs[15].Initiative = "16";
            Attribs[15].Name = "";
            Attribs[15].Lock = false;
            Attribs[15].InitRoll = "0";
            Attribs[15].ACLow = "0";
            Attribs[15].ACHigh = "0";
            Attribs[15].HP = "0";
            Attribs[15].ConditionA = "Normal";
            Attribs[15].ConditionB = "";

            Attribs[16].Visible = false;
            Attribs[16].Initiative = "17";
            Attribs[16].Name = "";
            Attribs[16].Lock = false;
            Attribs[16].InitRoll = "0";
            Attribs[16].ACLow = "0";
            Attribs[16].ACHigh = "0";
            Attribs[16].HP = "0";
            Attribs[16].ConditionA = "Normal";
            Attribs[16].ConditionB = "";

            Attribs[17].Visible = false;
            Attribs[17].Initiative = "18";
            Attribs[17].Name = "";
            Attribs[17].Lock = false;
            Attribs[17].InitRoll = "0";
            Attribs[17].ACLow = "0";
            Attribs[17].ACHigh = "0";
            Attribs[17].HP = "0";
            Attribs[17].ConditionA = "Normal";
            Attribs[17].ConditionB = "";

            Attribs[18].Visible = false;
            Attribs[18].Initiative = "19";
            Attribs[18].Name = "";
            Attribs[18].Lock = false;
            Attribs[18].InitRoll = "0";
            Attribs[18].ACLow = "0";
            Attribs[18].ACHigh = "0";
            Attribs[18].HP = "0";
            Attribs[18].ConditionA = "Normal";
            Attribs[18].ConditionB = "";

            Attribs[19].Visible = false;
            Attribs[19].Initiative = "20";
            Attribs[19].Name = "";
            Attribs[19].Lock = false;
            Attribs[19].InitRoll = "0";
            Attribs[19].ACLow = "0";
            Attribs[19].ACHigh = "0";
            Attribs[19].HP = "0";
            Attribs[19].ConditionA = "Normal";
            Attribs[19].ConditionB = "";

            countTotalPlayers();
        }

        public void loadValues_Test()
        {
            Attribs[0].Visible = true;
            Attribs[0].Initiative = "1";
            Attribs[0].Name = "Fenric";
            Attribs[0].Lock = true;
            Attribs[0].InitRoll = "1";
            Attribs[0].ACLow = "16";
            Attribs[0].ACHigh = "16";
            Attribs[0].HP = "76";
            Attribs[0].ConditionA = "Normal";
            Attribs[0].ConditionB = "";

            Attribs[1].Visible = true;
            Attribs[1].Initiative = "2";
            Attribs[1].Name = "Monster 1";
            Attribs[1].Lock = false;
            Attribs[1].InitRoll = "2";
            Attribs[1].ACLow = "12";
            Attribs[1].ACHigh = "16";
            Attribs[1].HP = "4";
            Attribs[1].ConditionA = "Dead";
            Attribs[1].ConditionB = "";

            Attribs[2].Visible = true;
            Attribs[2].Initiative = "3";
            Attribs[2].Name = "Monster 2";
            Attribs[2].Lock = false;
            Attribs[2].InitRoll = "3";
            Attribs[2].ACLow = "12";
            Attribs[2].ACHigh = "16";
            Attribs[2].HP = "4";
            Attribs[2].ConditionA = "Normal";
            Attribs[2].ConditionB = "";

            Attribs[3].Visible = true;
            Attribs[3].Initiative = "4";
            Attribs[3].Name = "Ash";
            Attribs[3].Lock = true;
            Attribs[3].InitRoll = "4";
            Attribs[3].ACLow = "17";
            Attribs[3].ACHigh = "17";
            Attribs[3].HP = "85";
            Attribs[3].ConditionA = "Normal";
            Attribs[3].ConditionB = "";

            Attribs[4].Visible = true;
            Attribs[4].Initiative = "5";
            Attribs[4].Name = "Opal";
            Attribs[4].Lock = true;
            Attribs[4].InitRoll = "5";
            Attribs[4].ACLow = "16";
            Attribs[4].ACHigh = "16";
            Attribs[4].HP = "28";
            Attribs[4].ConditionA = "Normal";
            Attribs[4].ConditionB = "";

            Attribs[5].Visible = true;
            Attribs[5].Initiative = "6";
            Attribs[5].Name = "Monster 3";
            Attribs[5].Lock = false;
            Attribs[5].InitRoll = "6";
            Attribs[5].ACLow = "12";
            Attribs[5].ACHigh = "16";
            Attribs[5].HP = "22";
            Attribs[5].ConditionA = "Normal";
            Attribs[5].ConditionB = "";

            Attribs[6].Visible = true;
            Attribs[6].Initiative = "7";
            Attribs[6].Name = "Theris";
            Attribs[6].Lock = true;
            Attribs[6].InitRoll = "7";
            Attribs[6].ACLow = "17";
            Attribs[6].ACHigh = "17";
            Attribs[6].HP = "22";
            Attribs[6].ConditionA = "Blinded";
            Attribs[6].ConditionB = "";

            Attribs[7].Visible = true;
            Attribs[7].Initiative = "8";
            Attribs[7].Name = "Monster 4";
            Attribs[7].Lock = false;
            Attribs[7].InitRoll = "8";
            Attribs[7].ACLow = "12";
            Attribs[7].ACHigh = "16";
            Attribs[7].HP = "4";
            Attribs[7].ConditionA = "Dead";
            Attribs[7].ConditionB = "";

            Attribs[8].Visible = true;
            Attribs[8].Initiative = "9";
            Attribs[8].Name = "Monster 5";
            Attribs[8].Lock = false;
            Attribs[8].InitRoll = "9";
            Attribs[8].ACLow = "12";
            Attribs[8].ACHigh = "16";
            Attribs[8].HP = "4";
            Attribs[8].ConditionA = "Prone";
            Attribs[8].ConditionB = "Grappled";

            Attribs[9].Visible = false;
            Attribs[9].Initiative = "10";
            Attribs[9].Name = "Monster 6";
            Attribs[9].Lock = false;
            Attribs[9].InitRoll = "0";
            Attribs[9].ACLow = "12";
            Attribs[9].ACHigh = "16";
            Attribs[9].HP = "4";
            Attribs[9].ConditionA = "Normal";
            Attribs[9].ConditionB = "";

            Attribs[10].Visible = false;
            Attribs[10].Initiative = "11";
            Attribs[10].Name = "";
            Attribs[10].Lock = false;
            Attribs[10].InitRoll = "0";
            Attribs[10].ACLow = "0";
            Attribs[10].ACHigh = "0";
            Attribs[10].HP = "0";
            Attribs[10].ConditionA = "Normal";
            Attribs[10].ConditionB = "";

            Attribs[11].Visible = false;
            Attribs[11].Initiative = "12";
            Attribs[11].Name = "";
            Attribs[11].Lock = false;
            Attribs[11].InitRoll = "0";
            Attribs[11].ACLow = "0";
            Attribs[11].ACHigh = "0";
            Attribs[11].HP = "0";
            Attribs[11].ConditionA = "Normal";
            Attribs[11].ConditionB = "";

            Attribs[12].Visible = false;
            Attribs[12].Initiative = "13";
            Attribs[12].Name = "";
            Attribs[12].Lock = false;
            Attribs[12].InitRoll = "0";
            Attribs[12].ACLow = "0";
            Attribs[12].ACHigh = "0";
            Attribs[12].HP = "0";
            Attribs[12].ConditionA = "Normal";
            Attribs[12].ConditionB = "";

            Attribs[13].Visible = false;
            Attribs[13].Initiative = "14";
            Attribs[13].Name = "";
            Attribs[13].Lock = false;
            Attribs[13].InitRoll = "0";
            Attribs[13].ACLow = "0";
            Attribs[13].ACHigh = "0";
            Attribs[13].HP = "0";
            Attribs[13].ConditionA = "Normal";
            Attribs[13].ConditionB = "";

            Attribs[14].Visible = false;
            Attribs[14].Initiative = "15";
            Attribs[14].Name = "";
            Attribs[14].Lock = false;
            Attribs[14].InitRoll = "0";
            Attribs[14].ACLow = "0";
            Attribs[14].ACHigh = "0";
            Attribs[14].HP = "0";
            Attribs[14].ConditionA = "Normal";
            Attribs[14].ConditionB = "";

            Attribs[15].Visible = false;
            Attribs[15].Initiative = "16";
            Attribs[15].Name = "";
            Attribs[15].Lock = false;
            Attribs[15].InitRoll = "0";
            Attribs[15].ACLow = "0";
            Attribs[15].ACHigh = "0";
            Attribs[15].HP = "0";
            Attribs[15].ConditionA = "Normal";
            Attribs[15].ConditionB = "";

            Attribs[16].Visible = false;
            Attribs[16].Initiative = "17";
            Attribs[16].Name = "";
            Attribs[16].Lock = false;
            Attribs[16].InitRoll = "0";
            Attribs[16].ACLow = "0";
            Attribs[16].ACHigh = "0";
            Attribs[16].HP = "0";
            Attribs[16].ConditionA = "Normal";
            Attribs[16].ConditionB = "";

            Attribs[17].Visible = false;
            Attribs[17].Initiative = "18";
            Attribs[17].Name = "";
            Attribs[17].Lock = false;
            Attribs[17].InitRoll = "0";
            Attribs[17].ACLow = "0";
            Attribs[17].ACHigh = "0";
            Attribs[17].HP = "0";
            Attribs[17].ConditionA = "Normal";
            Attribs[17].ConditionB = "";

            Attribs[18].Visible = false;
            Attribs[18].Initiative = "19";
            Attribs[18].Name = "";
            Attribs[18].Lock = false;
            Attribs[18].InitRoll = "0";
            Attribs[18].ACLow = "0";
            Attribs[18].ACHigh = "0";
            Attribs[18].HP = "0";
            Attribs[18].ConditionA = "Normal";
            Attribs[18].ConditionB = "";

            Attribs[19].Visible = false;
            Attribs[19].Initiative = "20";
            Attribs[19].Name = "";
            Attribs[19].Lock = false;
            Attribs[19].InitRoll = "0";
            Attribs[19].ACLow = "0";
            Attribs[19].ACHigh = "0";
            Attribs[19].HP = "0";
            Attribs[19].ConditionA = "Normal";
            Attribs[19].ConditionB = "";

            countTotalPlayers();
        }
        public void loadValues_File()
        {
            try
            {
                string[] strFile = System.IO.File.ReadAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"InitiativeTracker.txt")); ;

                string[] strFirstLine = strFile[0].Split(',');
                if (strFirstLine[0] == "1")
                    bDMMode = true;
                else
                    bDMMode = false;
                iCurrentInitiative = Int32.Parse(strFirstLine[1]);

                for (int x = 0; x < strFile.Length - 1; x++)
                {
                    string[] strLine = strFile[x + 1].Split(',');
                    Attribs[x].Initiative = strLine[0];
                    Attribs[x].Name = strLine[1];

                    if (strLine[2] == "1")
                        Attribs[x].Lock = true;
                    else
                        Attribs[x].Lock = false;

                    if (strLine[3] == "1")
                        Attribs[x].Visible = true;
                    else
                        Attribs[x].Visible = false;

                    Attribs[x].InitRoll = strLine[4];
                    Attribs[x].ACLow = strLine[5];
                    Attribs[x].ACHigh = strLine[6];
                    Attribs[x].HP = strLine[7];
                    Attribs[x].ConditionA = strLine[8];
                    Attribs[x].ConditionB = strLine[9];
                }
                countTotalPlayers();
            }
            catch (Exception ex)
            {
                loadValues_Blank();
            }
        }
        public void clearCharacter(int index)
        {
            Attribs[index].Visible = false;
            Attribs[index].Initiative = "20";
            Attribs[index].Name = "";
            Attribs[index].Lock = false;
            Attribs[index].InitRoll = "0";
            Attribs[index].ACLow = "0";
            Attribs[index].ACHigh = "0";
            Attribs[index].HP = "0";
            Attribs[index].ConditionA = "";
            Attribs[index].ConditionB = "";
        }
        public void resetInitiatives()
        {
            Attribs[0].Initiative = "1";
            Attribs[1].Initiative = "2";
            Attribs[2].Initiative = "3";
            Attribs[3].Initiative = "4";
            Attribs[4].Initiative = "5";
            Attribs[5].Initiative = "6";
            Attribs[6].Initiative = "7";
            Attribs[7].Initiative = "8";
            Attribs[8].Initiative = "9";
            Attribs[9].Initiative = "10";
            Attribs[10].Initiative = "11";
            Attribs[11].Initiative = "12";
            Attribs[12].Initiative = "13";
            Attribs[13].Initiative = "14";
            Attribs[14].Initiative = "15";
            Attribs[15].Initiative = "16";
            Attribs[16].Initiative = "17";
            Attribs[17].Initiative = "18";
            Attribs[18].Initiative = "19";
            Attribs[19].Initiative = "20";
        }

        public void countTotalPlayers()  //Count how may are visible
        {
            int i;
            for (i=0; i < 20; i++)
            {
                if (Attribs[i].Visible != true)
                {
                    break;
                }
            }
            iTotalPlayers = i;
        }
    }
}
