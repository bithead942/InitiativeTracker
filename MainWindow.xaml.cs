using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InitiativeTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Character myCharacters;
        private static readonly Regex _regex = new Regex("[^0-9]"); //regex that matches allowed text
        public int MonsterNum = 1;

        public MainWindow()
        {
            InitializeComponent();
            myCharacters = new Character();
            myCharacters.loadValues_File();
            updateScreenValues();
            showActive();
            
            SetInitiative(myCharacters.iCurrentInitiative);
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            updateData();
            myCharacters.saveValues();
        }
        private void IsTextAllowed(object sender, TextCompositionEventArgs e)
        {
            e.Handled = _regex.IsMatch(e.Text);
        }

        //**********************************************************************************************************************
        #region "Character 1"
        private void btnUp1_MouseDown(object sender, RoutedEventArgs e)
        {
            //Do Nothing
        }

        private void lblAC1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (cbDMMode.IsChecked == false)
            {
                if (Lock2.IsChecked == false)
                    txtACLow2.Text = txtACLow1.Text;
                if (Lock3.IsChecked == false)
                    txtACLow3.Text = txtACLow1.Text;
                if (Lock4.IsChecked == false)
                    txtACLow4.Text = txtACLow1.Text;
                if (Lock5.IsChecked == false)
                    txtACLow5.Text = txtACLow1.Text;
                if (Lock6.IsChecked == false)
                    txtACLow6.Text = txtACLow1.Text;
                if (Lock7.IsChecked == false)
                    txtACLow7.Text = txtACLow1.Text;
                if (Lock8.IsChecked == false)
                    txtACLow8.Text = txtACLow1.Text;
                if (Lock9.IsChecked == false)
                    txtACLow9.Text = txtACLow1.Text;
                if (Lock10.IsChecked == false)
                    txtACLow10.Text = txtACLow1.Text;
                if (Lock11.IsChecked == false)
                    txtACLow11.Text = txtACLow1.Text;
                if (Lock12.IsChecked == false)
                    txtACLow12.Text = txtACLow1.Text;
                if (Lock13.IsChecked == false)
                    txtACLow13.Text = txtACLow1.Text;
                if (Lock14.IsChecked == false)
                    txtACLow14.Text = txtACLow1.Text;
                if (Lock15.IsChecked == false)
                    txtACLow15.Text = txtACLow1.Text;

                if (Lock2.IsChecked == false)
                    txtACHigh2.Text = txtACHigh1.Text;
                if (Lock3.IsChecked == false)
                    txtACHigh3.Text = txtACHigh1.Text;
                if (Lock4.IsChecked == false)
                    txtACHigh4.Text = txtACHigh1.Text;
                if (Lock5.IsChecked == false)
                    txtACHigh5.Text = txtACHigh1.Text;
                if (Lock6.IsChecked == false)
                    txtACHigh6.Text = txtACHigh1.Text;
                if (Lock7.IsChecked == false)
                    txtACHigh7.Text = txtACHigh1.Text;
                if (Lock8.IsChecked == false)
                    txtACHigh8.Text = txtACHigh1.Text;
                if (Lock9.IsChecked == false)
                    txtACHigh9.Text = txtACHigh1.Text;
                if (Lock10.IsChecked == false)
                    txtACHigh10.Text = txtACHigh1.Text;
                if (Lock11.IsChecked == false)
                    txtACHigh11.Text = txtACHigh1.Text;
                if (Lock12.IsChecked == false)
                    txtACHigh12.Text = txtACHigh1.Text;
                if (Lock13.IsChecked == false)
                    txtACHigh13.Text = txtACHigh1.Text;
                if (Lock14.IsChecked == false)
                    txtACHigh14.Text = txtACHigh1.Text;
                if (Lock15.IsChecked == false)
                    txtACHigh15.Text = txtACHigh1.Text;
            }
        }
        private void btnDown1_MouseDown(object sender, RoutedEventArgs e)
        {
            Character tempCharacters = new Character();
            updateData();

            if (myCharacters.Attribs[1].Visible == true)
            {
                tempCharacters.Attribs[0] = myCharacters.Attribs[0];
                myCharacters.Attribs[0] = myCharacters.Attribs[1];
                myCharacters.Attribs[1] = tempCharacters.Attribs[0];
                myCharacters.resetInitiatives();

                updateScreenValues();
                showActive();
                
                SetInitiative(myCharacters.iCurrentInitiative);
            }
        }

        private void btnDelete1_MouseDown(object sender, RoutedEventArgs e)
        {
            Character tempCharacters = new Character();

            updateData();
            tempCharacters = myCharacters;
            for (int x = 0; x <= myCharacters.iTotalPlayers - 1; x++)
            {
                myCharacters.Attribs[x] = tempCharacters.Attribs[x + 1];
            }
            myCharacters.clearCharacter(myCharacters.iTotalPlayers);  //delete bottom entry
            myCharacters.countTotalPlayers();
            myCharacters.resetInitiatives();

            updateScreenValues();
            showActive();
            
            SetInitiative(myCharacters.iCurrentInitiative);
        }

        private void Lock1_Clicked(object sender, RoutedEventArgs e)
        {
            if (Lock1.IsChecked == true)
            {
                if (cbDMMode.IsChecked == false)
                    spTracker1.Visibility = Visibility.Hidden;
                myCharacters.Attribs[0].Lock = true;
            }
            else
            {
                spTracker1.Visibility = Visibility.Visible;
                myCharacters.Attribs[0].Lock = false;
            }
        }


        private void Condition1a_DropDownClosed(object sender, EventArgs e)
        {
            if (Condition1a.Text == "Normal")
            {
                Condition1b.Visibility = Visibility.Hidden;
                borderCharacter1.Background = Brushes.White;
            }
            else if (Condition1a.Text == "Dead")
            {
                Condition1b.Visibility = Visibility.Hidden;
                borderCharacter1.Background = Brushes.LightGray;
            }
            else
            {
                Condition1b.Visibility = Visibility.Visible;
                borderCharacter1.Background = Brushes.White;
            }

            SetInitiative(myCharacters.iCurrentInitiative);

        }
        private void btnAddDamage1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int iTotalDamage = Int32.Parse(txtTotalDamage1.Text);
                iTotalDamage = iTotalDamage + Int32.Parse(txtAddDamageAmount1.Text);
                txtTotalDamage1.Text = iTotalDamage.ToString();
                txtAddDamageAmount1.Text = "";
            }
            catch (Exception ex)
            {

            }
        }

        private void btnSubtractDamage1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int iTotalDamage = Int32.Parse(txtTotalDamage1.Text);
                iTotalDamage = iTotalDamage - Int32.Parse(txtAddDamageAmount1.Text);
                if (iTotalDamage > 0)
                {
                    txtTotalDamage1.Text = iTotalDamage.ToString();
                }
                else
                {
                    txtTotalDamage1.Text = "0";
                    Condition1a.Text = "Dead";
                    borderCharacter1.Background = Brushes.LightGray;
                }
                txtAddDamageAmount1.Text = "";
            }
            catch (Exception ex)
            {

            }
        }
        private void txtInit1_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtInit1.SelectionLength == 0)
                txtInit1.SelectAll();
        }

        private void txtACLow1_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtACLow1.SelectionLength == 0)
                txtACLow1.SelectAll();
        }

        private void txtACHigh1_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtACHigh1.SelectionLength == 0)
                txtACHigh1.SelectAll();
        }

        private void txtTotalDamage1_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtTotalDamage1.SelectionLength == 0)
                txtTotalDamage1.SelectAll();
        }

        private void txtAddDamageAmount1_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtAddDamageAmount1.SelectionLength == 0)
                txtAddDamageAmount1.SelectAll();
        }
        private void updateData1()
        {
            //Visibility is updated by the delete function
            myCharacters.Attribs[0].Initiative = txtInitiative1.Text;
            myCharacters.Attribs[0].Name = txtName1.Text;
            //Lock is updated when it changes
            myCharacters.Attribs[0].InitRoll = txtInit1.Text;
            myCharacters.Attribs[0].ACLow = txtACLow1.Text;
            myCharacters.Attribs[0].ACHigh = txtACHigh1.Text;
            myCharacters.Attribs[0].HP = txtTotalDamage1.Text;
            myCharacters.Attribs[0].ConditionA = Condition1a.Text;
            myCharacters.Attribs[0].ConditionB = Condition1b.Text;
        }

        #endregion

        //**********************************************************************************************************************
        #region "Character 2"
        private void btnUp2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Character tempCharacters = new Character();
            updateData();

            tempCharacters.Attribs[0] = myCharacters.Attribs[0];
            myCharacters.Attribs[0] = myCharacters.Attribs[1];
            myCharacters.Attribs[1] = tempCharacters.Attribs[0];
            myCharacters.resetInitiatives();

            updateScreenValues();
            showActive();
            
            SetInitiative(myCharacters.iCurrentInitiative);
        }

        private void lblAC2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (cbDMMode.IsChecked == false)
            {
                if (Lock1.IsChecked == false)
                    txtACLow1.Text = txtACLow2.Text;
                if (Lock3.IsChecked == false)
                    txtACLow3.Text = txtACLow2.Text;
                if (Lock4.IsChecked == false)
                    txtACLow4.Text = txtACLow2.Text;
                if (Lock5.IsChecked == false)
                    txtACLow5.Text = txtACLow2.Text;
                if (Lock6.IsChecked == false)
                    txtACLow6.Text = txtACLow2.Text;
                if (Lock7.IsChecked == false)
                    txtACLow7.Text = txtACLow2.Text;
                if (Lock8.IsChecked == false)
                    txtACLow8.Text = txtACLow2.Text;
                if (Lock9.IsChecked == false)
                    txtACLow9.Text = txtACLow2.Text;
                if (Lock10.IsChecked == false)
                    txtACLow10.Text = txtACLow2.Text;
                if (Lock11.IsChecked == false)
                    txtACLow11.Text = txtACLow2.Text;
                if (Lock12.IsChecked == false)
                    txtACLow12.Text = txtACLow2.Text;
                if (Lock13.IsChecked == false)
                    txtACLow13.Text = txtACLow2.Text;
                if (Lock14.IsChecked == false)
                    txtACLow14.Text = txtACLow2.Text;
                if (Lock15.IsChecked == false)
                    txtACLow15.Text = txtACLow2.Text;

                if (Lock1.IsChecked == false)
                    txtACHigh1.Text = txtACHigh2.Text;
                if (Lock3.IsChecked == false)
                    txtACHigh3.Text = txtACHigh2.Text;
                if (Lock4.IsChecked == false)
                    txtACHigh4.Text = txtACHigh2.Text;
                if (Lock5.IsChecked == false)
                    txtACHigh5.Text = txtACHigh2.Text;
                if (Lock6.IsChecked == false)
                    txtACHigh6.Text = txtACHigh2.Text;
                if (Lock7.IsChecked == false)
                    txtACHigh7.Text = txtACHigh2.Text;
                if (Lock8.IsChecked == false)
                    txtACHigh8.Text = txtACHigh2.Text;
                if (Lock9.IsChecked == false)
                    txtACHigh9.Text = txtACHigh2.Text;
                if (Lock10.IsChecked == false)
                    txtACHigh10.Text = txtACHigh2.Text;
                if (Lock11.IsChecked == false)
                    txtACHigh11.Text = txtACHigh2.Text;
                if (Lock12.IsChecked == false)
                    txtACHigh12.Text = txtACHigh2.Text;
                if (Lock13.IsChecked == false)
                    txtACHigh13.Text = txtACHigh2.Text;
                if (Lock14.IsChecked == false)
                    txtACHigh14.Text = txtACHigh2.Text;
                if (Lock15.IsChecked == false)
                    txtACHigh15.Text = txtACHigh2.Text;
            }
        }
        private void btnDown2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Character tempCharacters = new Character();
            updateData();

            if (myCharacters.Attribs[2].Visible == true)
            {
                tempCharacters.Attribs[1] = myCharacters.Attribs[1];
                myCharacters.Attribs[1] = myCharacters.Attribs[2];
                myCharacters.Attribs[2] = tempCharacters.Attribs[1];
                myCharacters.resetInitiatives();

                updateScreenValues();
                showActive();
                
                SetInitiative(myCharacters.iCurrentInitiative);
            }
        }

        private void btnDelete2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Character tempCharacters = new Character();

            updateData();
            tempCharacters = myCharacters;
            for (int x = 1; x <= myCharacters.iTotalPlayers - 1; x++)
            {
                myCharacters.Attribs[x] = tempCharacters.Attribs[x + 1];
            }
            myCharacters.clearCharacter(myCharacters.iTotalPlayers);  //delete bottom entry
            myCharacters.countTotalPlayers();
            myCharacters.resetInitiatives();

            updateScreenValues();
            showActive();
            
            SetInitiative(myCharacters.iCurrentInitiative);
        }

        private void Lock2_Clicked(object sender, RoutedEventArgs e)
        {
            if (Lock2.IsChecked == true)
            {
                if (cbDMMode.IsChecked == false)
                    spTracker2.Visibility = Visibility.Hidden;
                myCharacters.Attribs[1].Lock = true;
            }
            else
            {
                spTracker2.Visibility = Visibility.Visible;
                myCharacters.Attribs[1].Lock = false;
            }
        }


        private void Condition2a_DropDownClosed(object sender, EventArgs e)
        {
            if (Condition2a.Text == "Normal")
            {
                Condition2b.Visibility = Visibility.Hidden;
                borderCharacter2.Background = Brushes.White;
            }
            else if (Condition2a.Text == "Dead")
            {
                Condition2b.Visibility = Visibility.Hidden;
                borderCharacter2.Background = Brushes.LightGray;
            }
            else
            {
                Condition2b.Visibility = Visibility.Visible;
                borderCharacter2.Background = Brushes.White;
            }

            SetInitiative(myCharacters.iCurrentInitiative);
        }
        private void btnAddDamage2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int iTotalDamage = Int32.Parse(txtTotalDamage2.Text);
                iTotalDamage = iTotalDamage + Int32.Parse(txtAddDamageAmount2.Text);
                txtTotalDamage2.Text = iTotalDamage.ToString();
                txtAddDamageAmount2.Text = "";
            }
            catch (Exception ex)
            {

            }
        }

        private void btnSubtractDamage2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int iTotalDamage = Int32.Parse(txtTotalDamage2.Text);
                iTotalDamage = iTotalDamage - Int32.Parse(txtAddDamageAmount2.Text);
                if (iTotalDamage > 0)
                {
                    txtTotalDamage2.Text = iTotalDamage.ToString();
                }
                else
                {
                    txtTotalDamage2.Text = "0";
                    Condition2a.Text = "Dead";
                    borderCharacter2.Background = Brushes.LightGray;
                }
                txtAddDamageAmount2.Text = "";
            }
            catch (Exception ex)
            {

            }
        }
        private void txtInit2_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtInit2.SelectionLength == 0)
                txtInit2.SelectAll();
        }

        private void txtACLow2_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtACLow2.SelectionLength == 0)
                txtACLow2.SelectAll();
        }

        private void txtACHigh2_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtACHigh2.SelectionLength == 0)
                txtACHigh2.SelectAll();
        }

        private void txtTotalDamage2_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtTotalDamage2.SelectionLength == 0)
                txtTotalDamage2.SelectAll();
        }

        private void txtAddDamageAmount2_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtAddDamageAmount2.SelectionLength == 0)
                txtAddDamageAmount2.SelectAll();
        }
        private void updateData2()
        {
            //Visibility is updated by the delete function
            myCharacters.Attribs[1].Initiative = txtInitiative2.Text;
            myCharacters.Attribs[1].Name = txtName2.Text;
            //Lock is updated when it changes
            myCharacters.Attribs[1].InitRoll = txtInit2.Text;
            myCharacters.Attribs[1].ACLow = txtACLow2.Text;
            myCharacters.Attribs[1].ACHigh = txtACHigh2.Text;
            myCharacters.Attribs[1].HP = txtTotalDamage2.Text;
            myCharacters.Attribs[1].ConditionA = Condition2a.Text;
            myCharacters.Attribs[1].ConditionB = Condition2b.Text;
        }

        #endregion

        //**********************************************************************************************************************
        #region "Character 3"
        private void lblAC3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (cbDMMode.IsChecked == false)
            {
                if (Lock1.IsChecked == false)
                    txtACLow1.Text = txtACLow3.Text;
                if (Lock2.IsChecked == false)
                    txtACLow2.Text = txtACLow3.Text;
                if (Lock4.IsChecked == false)
                    txtACLow4.Text = txtACLow3.Text;
                if (Lock5.IsChecked == false)
                    txtACLow5.Text = txtACLow3.Text;
                if (Lock6.IsChecked == false)
                    txtACLow6.Text = txtACLow3.Text;
                if (Lock7.IsChecked == false)
                    txtACLow7.Text = txtACLow3.Text;
                if (Lock8.IsChecked == false)
                    txtACLow8.Text = txtACLow3.Text;
                if (Lock9.IsChecked == false)
                    txtACLow9.Text = txtACLow3.Text;
                if (Lock10.IsChecked == false)
                    txtACLow10.Text = txtACLow3.Text;
                if (Lock11.IsChecked == false)
                    txtACLow11.Text = txtACLow3.Text;
                if (Lock12.IsChecked == false)
                    txtACLow12.Text = txtACLow3.Text;
                if (Lock13.IsChecked == false)
                    txtACLow13.Text = txtACLow3.Text;
                if (Lock14.IsChecked == false)
                    txtACLow14.Text = txtACLow3.Text;
                if (Lock15.IsChecked == false)
                    txtACLow15.Text = txtACLow3.Text;

                if (Lock1.IsChecked == false)
                    txtACHigh1.Text = txtACHigh3.Text;
                if (Lock2.IsChecked == false)
                    txtACHigh2.Text = txtACHigh3.Text;
                if (Lock4.IsChecked == false)
                    txtACHigh4.Text = txtACHigh3.Text;
                if (Lock5.IsChecked == false)
                    txtACHigh5.Text = txtACHigh3.Text;
                if (Lock6.IsChecked == false)
                    txtACHigh6.Text = txtACHigh3.Text;
                if (Lock7.IsChecked == false)
                    txtACHigh7.Text = txtACHigh3.Text;
                if (Lock8.IsChecked == false)
                    txtACHigh8.Text = txtACHigh3.Text;
                if (Lock9.IsChecked == false)
                    txtACHigh9.Text = txtACHigh3.Text;
                if (Lock10.IsChecked == false)
                    txtACHigh10.Text = txtACHigh3.Text;
                if (Lock11.IsChecked == false)
                    txtACHigh11.Text = txtACHigh3.Text;
                if (Lock12.IsChecked == false)
                    txtACHigh12.Text = txtACHigh3.Text;
                if (Lock13.IsChecked == false)
                    txtACHigh13.Text = txtACHigh3.Text;
                if (Lock14.IsChecked == false)
                    txtACHigh14.Text = txtACHigh3.Text;
                if (Lock15.IsChecked == false)
                    txtACHigh15.Text = txtACHigh3.Text;
            }
        }
        private void btnUp3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Character tempCharacters = new Character();
            updateData();

            tempCharacters.Attribs[1] = myCharacters.Attribs[1];
            myCharacters.Attribs[1] = myCharacters.Attribs[2];
            myCharacters.Attribs[2] = tempCharacters.Attribs[1];
            myCharacters.resetInitiatives();

            updateScreenValues();
            showActive();
            
            SetInitiative(myCharacters.iCurrentInitiative);
        }

        private void btnDown3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Character tempCharacters = new Character();
            updateData();

            if (myCharacters.Attribs[3].Visible == true)
            {
                tempCharacters.Attribs[2] = myCharacters.Attribs[2];
                myCharacters.Attribs[2] = myCharacters.Attribs[3];
                myCharacters.Attribs[3] = tempCharacters.Attribs[2];
                myCharacters.resetInitiatives();

                updateScreenValues();
                showActive();
                
                SetInitiative(myCharacters.iCurrentInitiative);
            }
        }

        private void btnDelete3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Character tempCharacters = new Character();

            updateData();
            tempCharacters = myCharacters;
            for (int x = 2; x <= myCharacters.iTotalPlayers - 1; x++)
            {
                myCharacters.Attribs[x] = tempCharacters.Attribs[x + 1];
            }
            myCharacters.clearCharacter(myCharacters.iTotalPlayers);  //delete bottom entry
            myCharacters.countTotalPlayers();
            myCharacters.resetInitiatives();

            updateScreenValues();
            showActive();
            
            SetInitiative(myCharacters.iCurrentInitiative);
        }
        private void Lock3_Clicked(object sender, RoutedEventArgs e)
        {
            if (Lock3.IsChecked == true)
            {
                if (cbDMMode.IsChecked == false)
                    spTracker3.Visibility = Visibility.Hidden;
                myCharacters.Attribs[2].Lock = true;
            }
            else
            {
                spTracker3.Visibility = Visibility.Visible;
                myCharacters.Attribs[2].Lock = false;
            }
        }


        private void Condition3a_DropDownClosed(object sender, EventArgs e)
        {
            if (Condition3a.Text == "Normal")
            {
                Condition3b.Visibility = Visibility.Hidden;
                borderCharacter3.Background = Brushes.White;
            }
            else if (Condition3a.Text == "Dead")
            {
                Condition3b.Visibility = Visibility.Hidden;
                borderCharacter3.Background = Brushes.LightGray;
            }
            else
            {
                Condition3b.Visibility = Visibility.Visible;
                borderCharacter3.Background = Brushes.White;
            }

            SetInitiative(myCharacters.iCurrentInitiative);
        }
        private void btnAddDamage3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int iTotalDamage = Int32.Parse(txtTotalDamage3.Text);
                iTotalDamage = iTotalDamage + Int32.Parse(txtAddDamageAmount3.Text);
                txtTotalDamage3.Text = iTotalDamage.ToString();
                txtAddDamageAmount3.Text = "";
            }
            catch (Exception ex)
            {

            }
        }

        private void btnSubtractDamage3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int iTotalDamage = Int32.Parse(txtTotalDamage3.Text);
                iTotalDamage = iTotalDamage - Int32.Parse(txtAddDamageAmount3.Text);
                if (iTotalDamage > 0)
                {
                    txtTotalDamage3.Text = iTotalDamage.ToString();
                }
                else
                {
                    txtTotalDamage3.Text = "0";
                    Condition3a.Text = "Dead";
                    borderCharacter3.Background = Brushes.LightGray;
                }
                txtAddDamageAmount3.Text = "";
            }
            catch (Exception ex)
            {

            }
        }
        private void txtInit3_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtInit3.SelectionLength == 0)
                txtInit3.SelectAll();
        }

        private void txtACLow3_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtACLow3.SelectionLength == 0)
                txtACLow3.SelectAll();
        }

        private void txtACHigh3_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtACHigh3.SelectionLength == 0)
                txtACHigh3.SelectAll();
        }

        private void txtTotalDamage3_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtTotalDamage3.SelectionLength == 0)
                txtTotalDamage3.SelectAll();
        }

        private void txtAddDamageAmount3_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtAddDamageAmount3.SelectionLength == 0)
                txtAddDamageAmount3.SelectAll();
        }
        private void updateData3()
        {
            //Visibility is updated by the delete function
            myCharacters.Attribs[2].Initiative = txtInitiative3.Text;
            myCharacters.Attribs[2].Name = txtName3.Text;
            //Lock is updated when it changes
            myCharacters.Attribs[2].InitRoll = txtInit3.Text;
            myCharacters.Attribs[2].ACLow = txtACLow3.Text;
            myCharacters.Attribs[2].ACHigh = txtACHigh3.Text;
            myCharacters.Attribs[2].HP = txtTotalDamage3.Text;
            myCharacters.Attribs[2].ConditionA = Condition3a.Text;
            myCharacters.Attribs[2].ConditionB = Condition3b.Text;
        }
        #endregion

        //**********************************************************************************************************************
        #region "Character 4"

        private void lblAC4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (cbDMMode.IsChecked == false)
            {
                if (Lock1.IsChecked == false)
                    txtACLow1.Text = txtACLow4.Text;
                if (Lock2.IsChecked == false)
                    txtACLow2.Text = txtACLow4.Text;
                if (Lock3.IsChecked == false)
                    txtACLow3.Text = txtACLow4.Text;
                if (Lock5.IsChecked == false)
                    txtACLow5.Text = txtACLow4.Text;
                if (Lock6.IsChecked == false)
                    txtACLow6.Text = txtACLow4.Text;
                if (Lock7.IsChecked == false)
                    txtACLow7.Text = txtACLow4.Text;
                if (Lock8.IsChecked == false)
                    txtACLow8.Text = txtACLow4.Text;
                if (Lock9.IsChecked == false)
                    txtACLow9.Text = txtACLow4.Text;
                if (Lock10.IsChecked == false)
                    txtACLow10.Text = txtACLow4.Text;
                if (Lock11.IsChecked == false)
                    txtACLow11.Text = txtACLow4.Text;
                if (Lock12.IsChecked == false)
                    txtACLow12.Text = txtACLow4.Text;
                if (Lock13.IsChecked == false)
                    txtACLow13.Text = txtACLow4.Text;
                if (Lock14.IsChecked == false)
                    txtACLow14.Text = txtACLow4.Text;
                if (Lock15.IsChecked == false)
                    txtACLow15.Text = txtACLow4.Text;

                if (Lock1.IsChecked == false)
                    txtACHigh1.Text = txtACHigh4.Text;
                if (Lock2.IsChecked == false)
                    txtACHigh2.Text = txtACHigh4.Text;
                if (Lock3.IsChecked == false)
                    txtACHigh3.Text = txtACHigh4.Text;
                if (Lock5.IsChecked == false)
                    txtACHigh5.Text = txtACHigh4.Text;
                if (Lock6.IsChecked == false)
                    txtACHigh6.Text = txtACHigh4.Text;
                if (Lock7.IsChecked == false)
                    txtACHigh7.Text = txtACHigh4.Text;
                if (Lock8.IsChecked == false)
                    txtACHigh8.Text = txtACHigh4.Text;
                if (Lock9.IsChecked == false)
                    txtACHigh9.Text = txtACHigh4.Text;
                if (Lock10.IsChecked == false)
                    txtACHigh10.Text = txtACHigh4.Text;
                if (Lock11.IsChecked == false)
                    txtACHigh11.Text = txtACHigh4.Text;
                if (Lock12.IsChecked == false)
                    txtACHigh12.Text = txtACHigh4.Text;
                if (Lock13.IsChecked == false)
                    txtACHigh13.Text = txtACHigh4.Text;
                if (Lock14.IsChecked == false)
                    txtACHigh14.Text = txtACHigh4.Text;
                if (Lock15.IsChecked == false)
                    txtACHigh15.Text = txtACHigh4.Text;
            }
        }
        private void btnUp4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Character tempCharacters = new Character();
            updateData();

            tempCharacters.Attribs[2] = myCharacters.Attribs[2];
            myCharacters.Attribs[2] = myCharacters.Attribs[3];
            myCharacters.Attribs[3] = tempCharacters.Attribs[2];
            myCharacters.resetInitiatives();

            updateScreenValues();
            showActive();
            
            SetInitiative(myCharacters.iCurrentInitiative);
        }
        private void btnDown4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Character tempCharacters = new Character();
            updateData();

            if (myCharacters.Attribs[4].Visible == true)
            {
                tempCharacters.Attribs[3] = myCharacters.Attribs[3];
                myCharacters.Attribs[3] = myCharacters.Attribs[4];
                myCharacters.Attribs[4] = tempCharacters.Attribs[3];
                myCharacters.resetInitiatives();

                updateScreenValues();
                showActive();
                
                SetInitiative(myCharacters.iCurrentInitiative);
            }
        }
        private void btnDelete4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Character tempCharacters = new Character();

            updateData();
            tempCharacters = myCharacters;
            for (int x = 3; x <= myCharacters.iTotalPlayers - 1; x++)
            {
                myCharacters.Attribs[x] = tempCharacters.Attribs[x + 1];
            }
            myCharacters.clearCharacter(myCharacters.iTotalPlayers);  //delete bottom entry
            myCharacters.countTotalPlayers();
            myCharacters.resetInitiatives();

            updateScreenValues();
            showActive();
            
            SetInitiative(myCharacters.iCurrentInitiative);
        }
        private void Lock4_Clicked(object sender, RoutedEventArgs e)
        {
            if (Lock4.IsChecked == true)
            {
                if (cbDMMode.IsChecked == false)
                    spTracker4.Visibility = Visibility.Hidden;
                myCharacters.Attribs[3].Lock = true;
            }
            else
            {
                spTracker4.Visibility = Visibility.Visible;
                myCharacters.Attribs[3].Lock = false;
            }
        }


        private void Condition4a_DropDownClosed(object sender, EventArgs e)
        {
            if (Condition4a.Text == "Normal")
            {
                Condition4b.Visibility = Visibility.Hidden;
                borderCharacter4.Background = Brushes.White;
            }
            else if (Condition4a.Text == "Dead")
            {
                Condition4b.Visibility = Visibility.Hidden;
                borderCharacter4.Background = Brushes.LightGray;
            }
            else
            {
                Condition4b.Visibility = Visibility.Visible;
                borderCharacter4.Background = Brushes.White;
            }

            SetInitiative(myCharacters.iCurrentInitiative);
        }
        private void btnAddDamage4_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int iTotalDamage = Int32.Parse(txtTotalDamage4.Text);
                iTotalDamage = iTotalDamage + Int32.Parse(txtAddDamageAmount4.Text);
                txtTotalDamage4.Text = iTotalDamage.ToString();
                txtAddDamageAmount4.Text = "";
            }
            catch (Exception ex)
            {

            }
        }

        private void btnSubtractDamage4_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int iTotalDamage = Int32.Parse(txtTotalDamage4.Text);
                iTotalDamage = iTotalDamage - Int32.Parse(txtAddDamageAmount4.Text);
                if (iTotalDamage > 0)
                {
                    txtTotalDamage4.Text = iTotalDamage.ToString();
                }
                else
                {
                    txtTotalDamage4.Text = "0";
                    Condition4a.Text = "Dead";
                    borderCharacter4.Background = Brushes.LightGray;
                }
                txtAddDamageAmount4.Text = "";
            }
            catch (Exception ex)
            {

            }
        }
        private void txtInit4_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtInit4.SelectionLength == 0)
                txtInit4.SelectAll();
        }

        private void txtACLow4_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtACLow4.SelectionLength == 0)
                txtACLow4.SelectAll();
        }

        private void txtACHigh4_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtACHigh4.SelectionLength == 0)
                txtACHigh4.SelectAll();
        }

        private void txtTotalDamage4_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtTotalDamage4.SelectionLength == 0)
                txtTotalDamage4.SelectAll();
        }

        private void txtAddDamageAmount4_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtAddDamageAmount4.SelectionLength == 0)
                txtAddDamageAmount4.SelectAll();
        }
        private void updateData4()
        {
            //Visibility is updated by the delete function
            myCharacters.Attribs[3].Initiative = txtInitiative4.Text;
            myCharacters.Attribs[3].Name = txtName4.Text;
            //Lock is updated when it changes
            myCharacters.Attribs[3].InitRoll = txtInit4.Text;
            myCharacters.Attribs[3].ACLow = txtACLow4.Text;
            myCharacters.Attribs[3].ACHigh = txtACHigh4.Text;
            myCharacters.Attribs[3].HP = txtTotalDamage4.Text;
            myCharacters.Attribs[3].ConditionA = Condition4a.Text;
            myCharacters.Attribs[3].ConditionB = Condition4b.Text;
        }
        #endregion

        //**********************************************************************************************************************
        #region "Character 5"

        private void lblAC5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (cbDMMode.IsChecked == false)
            {
                if (Lock1.IsChecked == false)
                    txtACLow1.Text = txtACLow5.Text;
                if (Lock2.IsChecked == false)
                    txtACLow2.Text = txtACLow5.Text;
                if (Lock3.IsChecked == false)
                    txtACLow3.Text = txtACLow5.Text;
                if (Lock4.IsChecked == false)
                    txtACLow4.Text = txtACLow5.Text;
                if (Lock6.IsChecked == false)
                    txtACLow6.Text = txtACLow5.Text;
                if (Lock7.IsChecked == false)
                    txtACLow7.Text = txtACLow5.Text;
                if (Lock8.IsChecked == false)
                    txtACLow8.Text = txtACLow5.Text;
                if (Lock9.IsChecked == false)
                    txtACLow9.Text = txtACLow5.Text;
                if (Lock10.IsChecked == false)
                    txtACLow10.Text = txtACLow5.Text;
                if (Lock11.IsChecked == false)
                    txtACLow11.Text = txtACLow5.Text;
                if (Lock12.IsChecked == false)
                    txtACLow12.Text = txtACLow5.Text;
                if (Lock13.IsChecked == false)
                    txtACLow13.Text = txtACLow5.Text;
                if (Lock14.IsChecked == false)
                    txtACLow14.Text = txtACLow5.Text;
                if (Lock15.IsChecked == false)
                    txtACLow15.Text = txtACLow5.Text;

                if (Lock1.IsChecked == false)
                    txtACHigh1.Text = txtACHigh5.Text;
                if (Lock2.IsChecked == false)
                    txtACHigh2.Text = txtACHigh5.Text;
                if (Lock3.IsChecked == false)
                    txtACHigh3.Text = txtACHigh5.Text;
                if (Lock4.IsChecked == false)
                    txtACHigh4.Text = txtACHigh5.Text;
                if (Lock6.IsChecked == false)
                    txtACHigh6.Text = txtACHigh5.Text;
                if (Lock7.IsChecked == false)
                    txtACHigh7.Text = txtACHigh5.Text;
                if (Lock8.IsChecked == false)
                    txtACHigh8.Text = txtACHigh5.Text;
                if (Lock9.IsChecked == false)
                    txtACHigh9.Text = txtACHigh5.Text;
                if (Lock10.IsChecked == false)
                    txtACHigh10.Text = txtACHigh5.Text;
                if (Lock11.IsChecked == false)
                    txtACHigh11.Text = txtACHigh5.Text;
                if (Lock12.IsChecked == false)
                    txtACHigh12.Text = txtACHigh5.Text;
                if (Lock13.IsChecked == false)
                    txtACHigh13.Text = txtACHigh5.Text;
                if (Lock14.IsChecked == false)
                    txtACHigh14.Text = txtACHigh5.Text;
                if (Lock15.IsChecked == false)
                    txtACHigh15.Text = txtACHigh5.Text;
            }
        }
        private void btnUp5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Character tempCharacters = new Character();
            updateData();

            tempCharacters.Attribs[3] = myCharacters.Attribs[3];
            myCharacters.Attribs[3] = myCharacters.Attribs[4];
            myCharacters.Attribs[4] = tempCharacters.Attribs[3];
            myCharacters.resetInitiatives();

            updateScreenValues();
            showActive();
            
            SetInitiative(myCharacters.iCurrentInitiative);
        }

        private void btnDown5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Character tempCharacters = new Character();
            updateData();

            if (myCharacters.Attribs[5].Visible == true)
            {
                tempCharacters.Attribs[4] = myCharacters.Attribs[4];
                myCharacters.Attribs[4] = myCharacters.Attribs[5];
                myCharacters.Attribs[5] = tempCharacters.Attribs[4];
                myCharacters.resetInitiatives();

                updateScreenValues();
                showActive();
                
                SetInitiative(myCharacters.iCurrentInitiative);
            }
        }

        private void btnDelete5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Character tempCharacters = new Character();

            updateData();
            tempCharacters = myCharacters;
            for (int x = 4; x <= myCharacters.iTotalPlayers - 1; x++)
            {
                myCharacters.Attribs[x] = tempCharacters.Attribs[x + 1];
            }
            myCharacters.clearCharacter(myCharacters.iTotalPlayers);  //delete bottom entry
            myCharacters.countTotalPlayers();
            myCharacters.resetInitiatives();

            updateScreenValues();
            showActive();
            
            SetInitiative(myCharacters.iCurrentInitiative);
        }
        private void Lock5_Clicked(object sender, RoutedEventArgs e)
        {
            if (Lock5.IsChecked == true)
            {
                if (cbDMMode.IsChecked == false)
                    spTracker5.Visibility = Visibility.Hidden;
                myCharacters.Attribs[4].Lock = true;
            }
            else
            {
                spTracker5.Visibility = Visibility.Visible;
                myCharacters.Attribs[4].Lock = false;
            }
        }


        private void Condition5a_DropDownClosed(object sender, EventArgs e)
        {
            if (Condition5a.Text == "Normal")
            {
                Condition5b.Visibility = Visibility.Hidden;
                borderCharacter5.Background = Brushes.White;
            }
            else if (Condition5a.Text == "Dead")
            {
                Condition5b.Visibility = Visibility.Hidden;
                borderCharacter5.Background = Brushes.LightGray;
            }
            else
            {
                Condition5b.Visibility = Visibility.Visible;
                borderCharacter5.Background = Brushes.White;
            }

            SetInitiative(myCharacters.iCurrentInitiative);
        }
        private void btnAddDamage5_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int iTotalDamage = Int32.Parse(txtTotalDamage5.Text);
                iTotalDamage = iTotalDamage + Int32.Parse(txtAddDamageAmount5.Text);
                txtTotalDamage5.Text = iTotalDamage.ToString();
                txtAddDamageAmount5.Text = "";
            }
            catch (Exception ex)
            {

            }
        }

        private void btnSubtractDamage5_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int iTotalDamage = Int32.Parse(txtTotalDamage5.Text);
                iTotalDamage = iTotalDamage - Int32.Parse(txtAddDamageAmount5.Text);
                if (iTotalDamage > 0)
                {
                    txtTotalDamage5.Text = iTotalDamage.ToString();
                }
                else
                {
                    txtTotalDamage5.Text = "0";
                    Condition5a.Text = "Dead";
                    borderCharacter5.Background = Brushes.LightGray;
                }
                txtAddDamageAmount5.Text = "";
            }
            catch (Exception ex)
            {

            }
        }
        private void txtInit5_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtInit5.SelectionLength == 0)
                txtInit5.SelectAll();
        }

        private void txtACLow5_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtACLow5.SelectionLength == 0)
                txtACLow5.SelectAll();
        }

        private void txtACHigh5_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtACHigh5.SelectionLength == 0)
                txtACHigh5.SelectAll();
        }

        private void txtTotalDamage5_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtTotalDamage5.SelectionLength == 0)
                txtTotalDamage5.SelectAll();
        }

        private void txtAddDamageAmount5_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtAddDamageAmount5.SelectionLength == 0)
                txtAddDamageAmount5.SelectAll();
        }
        private void updateData5()
        {
            //Visibility is updated by the delete function
            myCharacters.Attribs[4].Initiative = txtInitiative5.Text;
            myCharacters.Attribs[4].Name = txtName5.Text;
            //Lock is updated when it changes
            myCharacters.Attribs[4].InitRoll = txtInit5.Text;
            myCharacters.Attribs[4].ACLow = txtACLow5.Text;
            myCharacters.Attribs[4].ACHigh = txtACHigh5.Text;
            myCharacters.Attribs[4].HP = txtTotalDamage5.Text;
            myCharacters.Attribs[4].ConditionA = Condition5a.Text;
            myCharacters.Attribs[4].ConditionB = Condition5b.Text;
        }

        #endregion

        //**********************************************************************************************************************
        #region "Character 6"
        private void lblAC6_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (cbDMMode.IsChecked == false)
            {
                if (Lock1.IsChecked == false)
                    txtACLow1.Text = txtACLow6.Text;
                if (Lock2.IsChecked == false)
                    txtACLow2.Text = txtACLow6.Text;
                if (Lock3.IsChecked == false)
                    txtACLow3.Text = txtACLow6.Text;
                if (Lock4.IsChecked == false)
                    txtACLow4.Text = txtACLow6.Text;
                if (Lock5.IsChecked == false)
                    txtACLow5.Text = txtACLow6.Text;
                if (Lock7.IsChecked == false)
                    txtACLow7.Text = txtACLow6.Text;
                if (Lock8.IsChecked == false)
                    txtACLow8.Text = txtACLow6.Text;
                if (Lock9.IsChecked == false)
                    txtACLow9.Text = txtACLow6.Text;
                if (Lock10.IsChecked == false)
                    txtACLow10.Text = txtACLow6.Text;
                if (Lock11.IsChecked == false)
                    txtACLow11.Text = txtACLow6.Text;
                if (Lock12.IsChecked == false)
                    txtACLow12.Text = txtACLow6.Text;
                if (Lock13.IsChecked == false)
                    txtACLow13.Text = txtACLow6.Text;
                if (Lock14.IsChecked == false)
                    txtACLow14.Text = txtACLow6.Text;
                if (Lock15.IsChecked == false)
                    txtACLow15.Text = txtACLow6.Text;

                if (Lock1.IsChecked == false)
                    txtACHigh1.Text = txtACHigh6.Text;
                if (Lock2.IsChecked == false)
                    txtACHigh2.Text = txtACHigh6.Text;
                if (Lock3.IsChecked == false)
                    txtACHigh3.Text = txtACHigh6.Text;
                if (Lock4.IsChecked == false)
                    txtACHigh4.Text = txtACHigh6.Text;
                if (Lock5.IsChecked == false)
                    txtACHigh5.Text = txtACHigh6.Text;
                if (Lock7.IsChecked == false)
                    txtACHigh7.Text = txtACHigh6.Text;
                if (Lock8.IsChecked == false)
                    txtACHigh8.Text = txtACHigh6.Text;
                if (Lock9.IsChecked == false)
                    txtACHigh9.Text = txtACHigh6.Text;
                if (Lock10.IsChecked == false)
                    txtACHigh10.Text = txtACHigh6.Text;
                if (Lock11.IsChecked == false)
                    txtACHigh11.Text = txtACHigh6.Text;
                if (Lock12.IsChecked == false)
                    txtACHigh12.Text = txtACHigh6.Text;
                if (Lock13.IsChecked == false)
                    txtACHigh13.Text = txtACHigh6.Text;
                if (Lock14.IsChecked == false)
                    txtACHigh4.Text = txtACHigh6.Text;
                if (Lock15.IsChecked == false)
                    txtACHigh15.Text = txtACHigh6.Text;
            }
        }

        private void btnUp6_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Character tempCharacters = new Character();
            updateData();

            tempCharacters.Attribs[4] = myCharacters.Attribs[4];
            myCharacters.Attribs[4] = myCharacters.Attribs[5];
            myCharacters.Attribs[5] = tempCharacters.Attribs[4];
            myCharacters.resetInitiatives();

            updateScreenValues();
            showActive();
            
            SetInitiative(myCharacters.iCurrentInitiative);
        }

        private void btnDown6_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Character tempCharacters = new Character();
            updateData();

            if (myCharacters.Attribs[6].Visible == true)
            {
                tempCharacters.Attribs[5] = myCharacters.Attribs[5];
                myCharacters.Attribs[5] = myCharacters.Attribs[6];
                myCharacters.Attribs[6] = tempCharacters.Attribs[5];
                myCharacters.resetInitiatives();

                updateScreenValues();
                showActive();
                
                SetInitiative(myCharacters.iCurrentInitiative);
            }
        }

        private void btnDelete6_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Character tempCharacters = new Character();

            updateData();
            tempCharacters = myCharacters;
            for (int x = 5; x <= myCharacters.iTotalPlayers - 1; x++)
            {
                myCharacters.Attribs[x] = tempCharacters.Attribs[x + 1];
            }
            myCharacters.clearCharacter(myCharacters.iTotalPlayers);  //delete bottom entry
            myCharacters.countTotalPlayers();
            myCharacters.resetInitiatives();

            updateScreenValues();
            showActive();
            
            SetInitiative(myCharacters.iCurrentInitiative);
        }
        private void Lock6_Clicked(object sender, RoutedEventArgs e)
        {
            if (Lock6.IsChecked == true)
            {
                if (cbDMMode.IsChecked == false)
                    spTracker6.Visibility = Visibility.Hidden;
                myCharacters.Attribs[5].Lock = true;
            }
            else
            {
                spTracker6.Visibility = Visibility.Visible;
                myCharacters.Attribs[5].Lock = false;
            }
        }


        private void Condition6a_DropDownClosed(object sender, EventArgs e)
        {
            if (Condition6a.Text == "Normal")
            {
                Condition6b.Visibility = Visibility.Hidden;
                borderCharacter6.Background = Brushes.White;
            }
            else if (Condition6a.Text == "Dead")
            {
                Condition6b.Visibility = Visibility.Hidden;
                borderCharacter6.Background = Brushes.LightGray;
            }
            else
            {
                Condition6b.Visibility = Visibility.Visible;
                borderCharacter6.Background = Brushes.White;
            }

            SetInitiative(myCharacters.iCurrentInitiative);
        }
        private void btnAddDamage6_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int iTotalDamage = Int32.Parse(txtTotalDamage6.Text);
                iTotalDamage = iTotalDamage + Int32.Parse(txtAddDamageAmount6.Text);
                txtTotalDamage6.Text = iTotalDamage.ToString();
                txtAddDamageAmount6.Text = "";
            }
            catch (Exception ex)
            {

            }
        }

        private void btnSubtractDamage6_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int iTotalDamage = Int32.Parse(txtTotalDamage6.Text);
                iTotalDamage = iTotalDamage - Int32.Parse(txtAddDamageAmount6.Text);
                if (iTotalDamage > 0)
                {
                    txtTotalDamage6.Text = iTotalDamage.ToString();
                }
                else
                {
                    txtTotalDamage6.Text = "0";
                    Condition6a.Text = "Dead";
                    borderCharacter6.Background = Brushes.LightGray;
                }
                txtAddDamageAmount6.Text = "";
            }
            catch (Exception ex)
            {

            }
        }

        private void txtInit6_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtInit6.SelectionLength == 0)
                txtInit6.SelectAll();
        }

        private void txtACLow6_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtACLow6.SelectionLength == 0)
                txtACLow6.SelectAll();
        }

        private void txtACHigh6_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtACHigh6.SelectionLength == 0)
                txtACHigh6.SelectAll();
        }

        private void txtTotalDamage6_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtTotalDamage6.SelectionLength == 0)
                txtTotalDamage6.SelectAll();
        }

        private void txtAddDamageAmount6_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtAddDamageAmount6.SelectionLength == 0)
                txtAddDamageAmount6.SelectAll();
        }
        private void updateData6()
        {
            //Visibility is updated by the delete function
            myCharacters.Attribs[5].Initiative = txtInitiative6.Text;
            myCharacters.Attribs[5].Name = txtName6.Text;
            //Lock is updated when it changes
            myCharacters.Attribs[5].InitRoll = txtInit6.Text;
            myCharacters.Attribs[5].ACLow = txtACLow6.Text;
            myCharacters.Attribs[5].ACHigh = txtACHigh6.Text;
            myCharacters.Attribs[5].HP = txtTotalDamage6.Text;
            myCharacters.Attribs[5].ConditionA = Condition6a.Text;
            myCharacters.Attribs[5].ConditionB = Condition6b.Text;
        }
        #endregion

        //**********************************************************************************************************************
        #region "Character 7"

        private void lblAC7_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (cbDMMode.IsChecked == false)
            {
                if (Lock1.IsChecked == false)
                    txtACLow1.Text = txtACLow7.Text;
                if (Lock2.IsChecked == false)
                    txtACLow2.Text = txtACLow7.Text;
                if (Lock3.IsChecked == false)
                    txtACLow3.Text = txtACLow7.Text;
                if (Lock4.IsChecked == false)
                    txtACLow4.Text = txtACLow7.Text;
                if (Lock5.IsChecked == false)
                    txtACLow5.Text = txtACLow7.Text;
                if (Lock6.IsChecked == false)
                    txtACLow6.Text = txtACLow7.Text;
                if (Lock8.IsChecked == false)
                    txtACLow8.Text = txtACLow7.Text;
                if (Lock9.IsChecked == false)
                    txtACLow9.Text = txtACLow7.Text;
                if (Lock10.IsChecked == false)
                    txtACLow10.Text = txtACLow7.Text;
                if (Lock11.IsChecked == false)
                    txtACLow11.Text = txtACLow7.Text;
                if (Lock12.IsChecked == false)
                    txtACLow12.Text = txtACLow7.Text;
                if (Lock13.IsChecked == false)
                    txtACLow13.Text = txtACLow7.Text;
                if (Lock14.IsChecked == false)
                    txtACLow14.Text = txtACLow7.Text;
                if (Lock15.IsChecked == false)
                    txtACLow15.Text = txtACLow7.Text;

                if (Lock1.IsChecked == false)
                    txtACHigh1.Text = txtACHigh7.Text;
                if (Lock2.IsChecked == false)
                    txtACHigh2.Text = txtACHigh7.Text;
                if (Lock3.IsChecked == false)
                    txtACHigh3.Text = txtACHigh7.Text;
                if (Lock4.IsChecked == false)
                    txtACHigh4.Text = txtACHigh7.Text;
                if (Lock5.IsChecked == false)
                    txtACHigh5.Text = txtACHigh7.Text;
                if (Lock6.IsChecked == false)
                    txtACHigh6.Text = txtACHigh7.Text;
                if (Lock8.IsChecked == false)
                    txtACHigh8.Text = txtACHigh7.Text;
                if (Lock9.IsChecked == false)
                    txtACHigh9.Text = txtACHigh7.Text;
                if (Lock10.IsChecked == false)
                    txtACHigh10.Text = txtACHigh7.Text;
                if (Lock11.IsChecked == false)
                    txtACHigh11.Text = txtACHigh7.Text;
                if (Lock12.IsChecked == false)
                    txtACHigh12.Text = txtACHigh7.Text;
                if (Lock13.IsChecked == false)
                    txtACHigh13.Text = txtACHigh7.Text;
                if (Lock14.IsChecked == false)
                    txtACHigh14.Text = txtACHigh7.Text;
                if (Lock15.IsChecked == false)
                    txtACHigh15.Text = txtACHigh7.Text;
            }
        }
        private void btnUp7_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Character tempCharacters = new Character();
            updateData();

            tempCharacters.Attribs[5] = myCharacters.Attribs[5];
            myCharacters.Attribs[5] = myCharacters.Attribs[6];
            myCharacters.Attribs[6] = tempCharacters.Attribs[5];
            myCharacters.resetInitiatives();

            updateScreenValues();
            showActive();
            
            SetInitiative(myCharacters.iCurrentInitiative);
        }

        private void btnDown7_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Character tempCharacters = new Character();
            updateData();

            if (myCharacters.Attribs[7].Visible == true)
            {
                tempCharacters.Attribs[6] = myCharacters.Attribs[6];
                myCharacters.Attribs[6] = myCharacters.Attribs[7];
                myCharacters.Attribs[7] = tempCharacters.Attribs[6];
                myCharacters.resetInitiatives();

                updateScreenValues();
                showActive();
                
                SetInitiative(myCharacters.iCurrentInitiative);
            }
        }

        private void btnDelete7_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Character tempCharacters = new Character();

            updateData();
            tempCharacters = myCharacters;
            for (int x = 6; x <= myCharacters.iTotalPlayers - 1; x++)
            {
                myCharacters.Attribs[x] = tempCharacters.Attribs[x + 1];
            }
            myCharacters.clearCharacter(myCharacters.iTotalPlayers);  //delete bottom entry
            myCharacters.countTotalPlayers();
            myCharacters.resetInitiatives();

            updateScreenValues();
            showActive();
            
            SetInitiative(myCharacters.iCurrentInitiative);
        }
        private void Lock7_Clicked(object sender, RoutedEventArgs e)
        {
            if (Lock7.IsChecked == true)
            {
                if (cbDMMode.IsChecked == false)
                    spTracker7.Visibility = Visibility.Hidden;
                myCharacters.Attribs[6].Lock = true;
            }
            else
            {
                spTracker7.Visibility = Visibility.Visible;
                myCharacters.Attribs[6].Lock = false;
            }
        }


        private void Condition7a_DropDownClosed(object sender, EventArgs e)
        {
            if (Condition7a.Text == "Normal")
            {
                Condition7b.Visibility = Visibility.Hidden;
                borderCharacter7.Background = Brushes.White;
            }
            else if (Condition7a.Text == "Dead")
            {
                Condition7b.Visibility = Visibility.Hidden;
                borderCharacter7.Background = Brushes.LightGray;
            }
            else
            {
                Condition7b.Visibility = Visibility.Visible;
                borderCharacter7.Background = Brushes.White;
            }

            SetInitiative(myCharacters.iCurrentInitiative);
        }
        private void btnAddDamage7_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int iTotalDamage = Int32.Parse(txtTotalDamage7.Text);
                iTotalDamage = iTotalDamage + Int32.Parse(txtAddDamageAmount7.Text);
                txtTotalDamage7.Text = iTotalDamage.ToString();
                txtAddDamageAmount7.Text = "";
            }
            catch (Exception ex)
            {

            }
        }

        private void btnSubtractDamage7_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int iTotalDamage = Int32.Parse(txtTotalDamage7.Text);
                iTotalDamage = iTotalDamage - Int32.Parse(txtAddDamageAmount7.Text);
                if (iTotalDamage > 0)
                {
                    txtTotalDamage7.Text = iTotalDamage.ToString();
                }
                else
                {
                    txtTotalDamage7.Text = "0";
                    Condition7a.Text = "Dead";
                    borderCharacter7.Background = Brushes.LightGray;
                }
                txtAddDamageAmount7.Text = "";
            }
            catch (Exception ex)
            {

            }
        }
        private void txtInit7_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtInit7.SelectionLength == 0)
                txtInit7.SelectAll();
        }

        private void txtACLow7_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtACLow7.SelectionLength == 0)
                txtACLow7.SelectAll();
        }

        private void txtACHigh7_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtACHigh7.SelectionLength == 0)
                txtACHigh7.SelectAll();
        }

        private void txtTotalDamage7_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtTotalDamage7.SelectionLength == 0)
                txtTotalDamage7.SelectAll();
        }

        private void txtAddDamageAmount7_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtAddDamageAmount7.SelectionLength == 0)
                txtAddDamageAmount7.SelectAll();
        }
        private void updateData7()
        {
            //Visibility is updated by the delete function
            myCharacters.Attribs[6].Initiative = txtInitiative7.Text;
            myCharacters.Attribs[6].Name = txtName7.Text;
            //Lock is updated when it changes
            myCharacters.Attribs[6].InitRoll = txtInit7.Text;
            myCharacters.Attribs[6].ACLow = txtACLow7.Text;
            myCharacters.Attribs[6].ACHigh = txtACHigh7.Text;
            myCharacters.Attribs[6].HP = txtTotalDamage7.Text;
            myCharacters.Attribs[6].ConditionA = Condition7a.Text;
            myCharacters.Attribs[6].ConditionB = Condition7b.Text;
        }
        #endregion

        //**********************************************************************************************************************
        #region "Character 8"

        private void lblAC8_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (cbDMMode.IsChecked == false)
            {
                if (Lock1.IsChecked == false)
                    txtACLow1.Text = txtACLow8.Text;
                if (Lock2.IsChecked == false)
                    txtACLow2.Text = txtACLow8.Text;
                if (Lock3.IsChecked == false)
                    txtACLow3.Text = txtACLow8.Text;
                if (Lock4.IsChecked == false)
                    txtACLow4.Text = txtACLow8.Text;
                if (Lock5.IsChecked == false)
                    txtACLow5.Text = txtACLow8.Text;
                if (Lock6.IsChecked == false)
                    txtACLow6.Text = txtACLow8.Text;
                if (Lock7.IsChecked == false)
                    txtACLow7.Text = txtACLow8.Text;
                if (Lock9.IsChecked == false)
                    txtACLow9.Text = txtACLow8.Text;
                if (Lock10.IsChecked == false)
                    txtACLow10.Text = txtACLow8.Text;
                if (Lock11.IsChecked == false)
                    txtACLow11.Text = txtACLow8.Text;
                if (Lock12.IsChecked == false)
                    txtACLow12.Text = txtACLow8.Text;
                if (Lock13.IsChecked == false)
                    txtACLow13.Text = txtACLow8.Text;
                if (Lock14.IsChecked == false)
                    txtACLow14.Text = txtACLow8.Text;
                if (Lock15.IsChecked == false)
                    txtACLow15.Text = txtACLow8.Text;

                if (Lock1.IsChecked == false)
                    txtACHigh1.Text = txtACHigh8.Text;
                if (Lock2.IsChecked == false)
                    txtACHigh2.Text = txtACHigh8.Text;
                if (Lock3.IsChecked == false)
                    txtACHigh3.Text = txtACHigh8.Text;
                if (Lock4.IsChecked == false)
                    txtACHigh4.Text = txtACHigh8.Text;
                if (Lock5.IsChecked == false)
                    txtACHigh5.Text = txtACHigh8.Text;
                if (Lock6.IsChecked == false)
                    txtACHigh6.Text = txtACHigh8.Text;
                if (Lock7.IsChecked == false)
                    txtACHigh7.Text = txtACHigh8.Text;
                if (Lock9.IsChecked == false)
                    txtACHigh9.Text = txtACHigh8.Text;
                if (Lock10.IsChecked == false)
                    txtACHigh10.Text = txtACHigh8.Text;
                if (Lock11.IsChecked == false)
                    txtACHigh11.Text = txtACHigh8.Text;
                if (Lock12.IsChecked == false)
                    txtACHigh12.Text = txtACHigh8.Text;
                if (Lock13.IsChecked == false)
                    txtACHigh13.Text = txtACHigh8.Text;
                if (Lock14.IsChecked == false)
                    txtACHigh14.Text = txtACHigh8.Text;
                if (Lock15.IsChecked == false)
                    txtACHigh15.Text = txtACHigh8.Text;
            }
        }

        private void btnUp8_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Character tempCharacters = new Character();
            updateData();

            tempCharacters.Attribs[6] = myCharacters.Attribs[6];
            myCharacters.Attribs[6] = myCharacters.Attribs[7];
            myCharacters.Attribs[7] = tempCharacters.Attribs[6];
            myCharacters.resetInitiatives();

            updateScreenValues();
            showActive();
            
            SetInitiative(myCharacters.iCurrentInitiative);
        }

        private void btnDown8_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Character tempCharacters = new Character();
            updateData();

            if (myCharacters.Attribs[8].Visible == true)
            {
                tempCharacters.Attribs[7] = myCharacters.Attribs[7];
                myCharacters.Attribs[7] = myCharacters.Attribs[8];
                myCharacters.Attribs[8] = tempCharacters.Attribs[7];
                myCharacters.resetInitiatives();

                updateScreenValues();
                showActive();
                
                SetInitiative(myCharacters.iCurrentInitiative);
            }
        }

        private void btnDelete8_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Character tempCharacters = new Character();

            updateData();
            tempCharacters = myCharacters;
            for (int x = 7; x <= myCharacters.iTotalPlayers - 1; x++)
            {
                myCharacters.Attribs[x] = tempCharacters.Attribs[x + 1];
            }
            myCharacters.clearCharacter(myCharacters.iTotalPlayers);  //delete bottom entry
            myCharacters.countTotalPlayers();
            myCharacters.resetInitiatives();

            updateScreenValues();
            showActive();
            
            SetInitiative(myCharacters.iCurrentInitiative);
        }
        private void Lock8_Clicked(object sender, RoutedEventArgs e)
        {
            if (Lock8.IsChecked == true)
            {
                if (cbDMMode.IsChecked == false)
                    spTracker8.Visibility = Visibility.Hidden;
                myCharacters.Attribs[7].Lock = true;
            }
            else
            {
                spTracker8.Visibility = Visibility.Visible;
                myCharacters.Attribs[7].Lock = false;
            }
        }


        private void Condition8a_DropDownClosed(object sender, EventArgs e)
        {
            if (Condition8a.Text == "Normal")
            {
                Condition8b.Visibility = Visibility.Hidden;
                borderCharacter8.Background = Brushes.White;
            }
            else if (Condition8a.Text == "Dead")
            {
                Condition8b.Visibility = Visibility.Hidden;
                borderCharacter8.Background = Brushes.LightGray;
            }
            else
            {
                Condition8b.Visibility = Visibility.Visible;
                borderCharacter8.Background = Brushes.White;
            }

            SetInitiative(myCharacters.iCurrentInitiative);
        }
        private void btnAddDamage8_Click(object sender, RoutedEventArgs e)
        {
            int iTotalDamage = Int32.Parse(txtTotalDamage8.Text);
            iTotalDamage = iTotalDamage + Int32.Parse(txtAddDamageAmount8.Text);
            txtTotalDamage8.Text = iTotalDamage.ToString();
            txtAddDamageAmount8.Text = "";
        }

        private void btnSubtractDamage8_Click(object sender, RoutedEventArgs e)
        {
            int iTotalDamage = Int32.Parse(txtTotalDamage8.Text);
            iTotalDamage = iTotalDamage - Int32.Parse(txtAddDamageAmount8.Text);
            if (iTotalDamage > 0)
            {
                txtTotalDamage8.Text = iTotalDamage.ToString();
            }
            else
            {
                txtTotalDamage8.Text = "0";
                Condition8a.Text = "Dead";
                borderCharacter8.Background = Brushes.LightGray;
            }
            txtAddDamageAmount8.Text = "";
        }
        private void txtInit8_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtInit8.SelectionLength == 0)
                txtInit8.SelectAll();
        }

        private void txtACLow8_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtACLow8.SelectionLength == 0)
                txtACLow8.SelectAll();
        }

        private void txtACHigh8_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtACHigh8.SelectionLength == 0)
                txtACHigh8.SelectAll();
        }

        private void txtTotalDamage8_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtTotalDamage8.SelectionLength == 0)
                txtTotalDamage8.SelectAll();
        }

        private void txtAddDamageAmount8_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtAddDamageAmount8.SelectionLength == 0)
                txtAddDamageAmount8.SelectAll();
        }
        private void updateData8()
        {
            //Visibility is updated by the delete function
            myCharacters.Attribs[7].Initiative = txtInitiative8.Text;
            myCharacters.Attribs[7].Name = txtName8.Text;
            //Lock is updated when it changes
            myCharacters.Attribs[7].InitRoll = txtInit8.Text;
            myCharacters.Attribs[7].ACLow = txtACLow8.Text;
            myCharacters.Attribs[7].ACHigh = txtACHigh8.Text;
            myCharacters.Attribs[7].HP = txtTotalDamage8.Text;
            myCharacters.Attribs[7].ConditionA = Condition8a.Text;
            myCharacters.Attribs[7].ConditionB = Condition8b.Text;
        }
        #endregion

        //**********************************************************************************************************************
        #region "Character 9"

        private void lblAC9_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (cbDMMode.IsChecked == false)
            {
                if (Lock1.IsChecked == false)
                    txtACLow1.Text = txtACLow9.Text;
                if (Lock2.IsChecked == false)
                    txtACLow2.Text = txtACLow9.Text;
                if (Lock3.IsChecked == false)
                    txtACLow3.Text = txtACLow9.Text;
                if (Lock4.IsChecked == false)
                    txtACLow4.Text = txtACLow9.Text;
                if (Lock5.IsChecked == false)
                    txtACLow5.Text = txtACLow9.Text;
                if (Lock6.IsChecked == false)
                    txtACLow6.Text = txtACLow9.Text;
                if (Lock7.IsChecked == false)
                    txtACLow7.Text = txtACLow9.Text;
                if (Lock8.IsChecked == false)
                    txtACLow8.Text = txtACLow9.Text;
                if (Lock10.IsChecked == false)
                    txtACLow10.Text = txtACLow9.Text;
                if (Lock11.IsChecked == false)
                    txtACLow11.Text = txtACLow9.Text;
                if (Lock12.IsChecked == false)
                    txtACLow12.Text = txtACLow9.Text;
                if (Lock13.IsChecked == false)
                    txtACLow13.Text = txtACLow9.Text;
                if (Lock14.IsChecked == false)
                    txtACLow14.Text = txtACLow9.Text;
                if (Lock15.IsChecked == false)
                    txtACLow15.Text = txtACLow9.Text;

                if (Lock1.IsChecked == false)
                    txtACHigh1.Text = txtACHigh9.Text;
                if (Lock2.IsChecked == false)
                    txtACHigh2.Text = txtACHigh9.Text;
                if (Lock3.IsChecked == false)
                    txtACHigh3.Text = txtACHigh9.Text;
                if (Lock4.IsChecked == false)
                    txtACHigh4.Text = txtACHigh9.Text;
                if (Lock5.IsChecked == false)
                    txtACHigh5.Text = txtACHigh9.Text;
                if (Lock6.IsChecked == false)
                    txtACHigh6.Text = txtACHigh9.Text;
                if (Lock7.IsChecked == false)
                    txtACHigh7.Text = txtACHigh9.Text;
                if (Lock8.IsChecked == false)
                    txtACHigh8.Text = txtACHigh9.Text;
                if (Lock10.IsChecked == false)
                    txtACHigh10.Text = txtACHigh9.Text;
                if (Lock11.IsChecked == false)
                    txtACHigh11.Text = txtACHigh9.Text;
                if (Lock12.IsChecked == false)
                    txtACHigh12.Text = txtACHigh9.Text;
                if (Lock13.IsChecked == false)
                    txtACHigh13.Text = txtACHigh9.Text;
                if (Lock14.IsChecked == false)
                    txtACHigh14.Text = txtACHigh9.Text;
                if (Lock15.IsChecked == false)
                    txtACHigh15.Text = txtACHigh9.Text;
            }
        }

        private void Condition9a_DropDownClosed_1(object sender, EventArgs e)
        {
            if (Condition9a.Text == "Normal")
            {
                Condition9b.Visibility = Visibility.Hidden;
                borderCharacter9.Background = Brushes.White;
            }
            else if (Condition9a.Text == "Dead")
            {
                Condition9b.Visibility = Visibility.Hidden;
                borderCharacter9.Background = Brushes.LightGray;
            }
            else
            {
                Condition9b.Visibility = Visibility.Visible;
                borderCharacter9.Background = Brushes.White;
            }

            SetInitiative(myCharacters.iCurrentInitiative);
        }


        private void btnUp9_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Character tempCharacters = new Character();
            updateData();

            tempCharacters.Attribs[7] = myCharacters.Attribs[7];
            myCharacters.Attribs[7] = myCharacters.Attribs[8];
            myCharacters.Attribs[8] = tempCharacters.Attribs[7];
            myCharacters.resetInitiatives();

            updateScreenValues();
            showActive();
            
            SetInitiative(myCharacters.iCurrentInitiative);
        }

        private void btnDown9_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Character tempCharacters = new Character();
            updateData();

            if (myCharacters.Attribs[9].Visible == true)
            {
                tempCharacters.Attribs[8] = myCharacters.Attribs[8];
                myCharacters.Attribs[8] = myCharacters.Attribs[9];
                myCharacters.Attribs[9] = tempCharacters.Attribs[8];
                myCharacters.resetInitiatives();

                updateScreenValues();
                showActive();
                
                SetInitiative(myCharacters.iCurrentInitiative);
            }
        }

        private void btnDelete9_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Character tempCharacters = new Character();

            updateData();
            tempCharacters = myCharacters;
            for (int x = 8; x <= myCharacters.iTotalPlayers - 1; x++)
            {
                myCharacters.Attribs[x] = tempCharacters.Attribs[x + 1];
            }
            myCharacters.clearCharacter(myCharacters.iTotalPlayers);  //delete bottom entry
            myCharacters.countTotalPlayers();
            myCharacters.resetInitiatives();

            updateScreenValues();
            showActive();
            
            SetInitiative(myCharacters.iCurrentInitiative);
        }
        private void Lock9_Clicked(object sender, RoutedEventArgs e)
        {
            if (Lock9.IsChecked == true)
            {
                if (cbDMMode.IsChecked == false)
                    spTracker9.Visibility = Visibility.Hidden;
                myCharacters.Attribs[8].Lock = true;
            }
            else
            {
                spTracker9.Visibility = Visibility.Visible;
                myCharacters.Attribs[8].Lock = false;
            }
        }


        private void Condition9a_DropDownClosed(object sender, EventArgs e)
        {
            if (Condition9a.Text == "Normal")
            {
                Condition9b.Visibility = Visibility.Hidden;
                borderCharacter9.Background = Brushes.White;
            }
            else if (Condition9a.Text == "Dead")
            {
                Condition9b.Visibility = Visibility.Hidden;
                borderCharacter9.Background = Brushes.LightGray;
            }
            else
            {
                Condition9b.Visibility = Visibility.Visible;
                borderCharacter9.Background = Brushes.White;
            }

            SetInitiative(myCharacters.iCurrentInitiative);
        }
        private void btnAddDamage9_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int iTotalDamage = Int32.Parse(txtTotalDamage9.Text);
                iTotalDamage = iTotalDamage + Int32.Parse(txtAddDamageAmount9.Text);
                txtTotalDamage9.Text = iTotalDamage.ToString();
                txtAddDamageAmount9.Text = "";
            }
            catch (Exception ex)
            {

            }
        }

        private void btnSubtractDamage9_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int iTotalDamage = Int32.Parse(txtTotalDamage9.Text);
                iTotalDamage = iTotalDamage - Int32.Parse(txtAddDamageAmount9.Text);
                if (iTotalDamage > 0)
                {
                    txtTotalDamage9.Text = iTotalDamage.ToString();
                }
                else
                {
                    txtTotalDamage9.Text = "0";
                    Condition9a.Text = "Dead";
                    borderCharacter9.Background = Brushes.LightGray;
                }
                txtAddDamageAmount9.Text = "";
            }
            catch (Exception ex)
            {

            }
        }
        private void txtInit9_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtInit9.SelectionLength == 0)
                txtInit9.SelectAll();
        }

        private void txtACLow9_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtACLow9.SelectionLength == 0)
                txtACLow9.SelectAll();
        }

        private void txtACHigh9_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtACHigh9.SelectionLength == 0)
                txtACHigh9.SelectAll();
        }

        private void txtTotalDamage9_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtTotalDamage9.SelectionLength == 0)
                txtTotalDamage9.SelectAll();
        }

        private void txtAddDamageAmount9_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtAddDamageAmount9.SelectionLength == 0)
                txtAddDamageAmount9.SelectAll();
        }
        private void updateData9()
        {
            //Visibility is updated by the delete function
            myCharacters.Attribs[8].Initiative = txtInitiative9.Text;
            myCharacters.Attribs[8].Name = txtName9.Text;
            //Lock is updated when it changes
            myCharacters.Attribs[8].InitRoll = txtInit9.Text;
            myCharacters.Attribs[8].ACLow = txtACLow9.Text;
            myCharacters.Attribs[8].ACHigh = txtACHigh9.Text;
            myCharacters.Attribs[8].HP = txtTotalDamage9.Text;
            myCharacters.Attribs[8].ConditionA = Condition9a.Text;
            myCharacters.Attribs[8].ConditionB = Condition9b.Text;
        }
        #endregion

        //**********************************************************************************************************************
        #region "Character 10"

        private void lblAC10_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (cbDMMode.IsChecked == false)
            {
                if (Lock1.IsChecked == false)
                    txtACLow1.Text = txtACLow10.Text;
                if (Lock2.IsChecked == false)
                    txtACLow2.Text = txtACLow10.Text;
                if (Lock3.IsChecked == false)
                    txtACLow3.Text = txtACLow10.Text;
                if (Lock4.IsChecked == false)
                    txtACLow4.Text = txtACLow10.Text;
                if (Lock5.IsChecked == false)
                    txtACLow5.Text = txtACLow10.Text;
                if (Lock6.IsChecked == false)
                    txtACLow6.Text = txtACLow10.Text;
                if (Lock7.IsChecked == false)
                    txtACLow7.Text = txtACLow10.Text;
                if (Lock8.IsChecked == false)
                    txtACLow8.Text = txtACLow10.Text;
                if (Lock9.IsChecked == false)
                    txtACLow9.Text = txtACLow10.Text;
                if (Lock11.IsChecked == false)
                    txtACLow11.Text = txtACLow10.Text;
                if (Lock12.IsChecked == false)
                    txtACLow12.Text = txtACLow10.Text;
                if (Lock13.IsChecked == false)
                    txtACLow13.Text = txtACLow10.Text;
                if (Lock14.IsChecked == false)
                    txtACLow14.Text = txtACLow10.Text;
                if (Lock15.IsChecked == false)
                    txtACLow15.Text = txtACLow10.Text;

                if (Lock1.IsChecked == false)
                    txtACHigh1.Text = txtACHigh10.Text;
                if (Lock2.IsChecked == false)
                    txtACHigh2.Text = txtACHigh10.Text;
                if (Lock3.IsChecked == false)
                    txtACHigh3.Text = txtACHigh10.Text;
                if (Lock4.IsChecked == false)
                    txtACHigh4.Text = txtACHigh10.Text;
                if (Lock5.IsChecked == false)
                    txtACHigh5.Text = txtACHigh10.Text;
                if (Lock6.IsChecked == false)
                    txtACHigh6.Text = txtACHigh10.Text;
                if (Lock7.IsChecked == false)
                    txtACHigh7.Text = txtACHigh10.Text;
                if (Lock8.IsChecked == false)
                    txtACHigh8.Text = txtACHigh10.Text;
                if (Lock9.IsChecked == false)
                    txtACHigh9.Text = txtACHigh10.Text;
                if (Lock11.IsChecked == false)
                    txtACHigh11.Text = txtACHigh10.Text;
                if (Lock12.IsChecked == false)
                    txtACHigh12.Text = txtACHigh10.Text;
                if (Lock13.IsChecked == false)
                    txtACHigh13.Text = txtACHigh10.Text;
                if (Lock14.IsChecked == false)
                    txtACHigh14.Text = txtACHigh10.Text;
                if (Lock15.IsChecked == false)
                    txtACHigh15.Text = txtACHigh10.Text;
            }
        }

        private void Condition10a_DropDownClosed_1(object sender, EventArgs e)
        {
            if (Condition10a.Text == "Normal")
            {
                Condition10b.Visibility = Visibility.Hidden;
                borderCharacter10.Background = Brushes.White;
            }
            else if (Condition10a.Text == "Dead")
            {
                Condition10b.Visibility = Visibility.Hidden;
                borderCharacter10.Background = Brushes.LightGray;
            }
            else
            {
                Condition10b.Visibility = Visibility.Visible;
                borderCharacter10.Background = Brushes.White;
            }

            SetInitiative(myCharacters.iCurrentInitiative);
        }

        private void btnUp10_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Character tempCharacters = new Character();
            updateData();

            tempCharacters.Attribs[8] = myCharacters.Attribs[8];
            myCharacters.Attribs[8] = myCharacters.Attribs[9];
            myCharacters.Attribs[9] = tempCharacters.Attribs[8];
            myCharacters.resetInitiatives();

            updateScreenValues();
            showActive();
            
            SetInitiative(myCharacters.iCurrentInitiative);
        }

        private void btnDown10_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Character tempCharacters = new Character();
            updateData();

            if (myCharacters.Attribs[10].Visible == true)
            {
                tempCharacters.Attribs[9] = myCharacters.Attribs[9];
                myCharacters.Attribs[9] = myCharacters.Attribs[10];
                myCharacters.Attribs[10] = tempCharacters.Attribs[9];
                myCharacters.resetInitiatives();

                updateScreenValues();
                showActive();
                
                SetInitiative(myCharacters.iCurrentInitiative);
            }
        }

        private void btnDelete10_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Character tempCharacters = new Character();

            updateData();
            tempCharacters = myCharacters;
            for (int x = 9; x <= myCharacters.iTotalPlayers - 1; x++)
            {
                myCharacters.Attribs[x] = tempCharacters.Attribs[x + 1];
            }
            myCharacters.clearCharacter(myCharacters.iTotalPlayers);  //delete bottom entry
            myCharacters.countTotalPlayers();
            myCharacters.resetInitiatives();

            updateScreenValues();
            showActive();
            
            SetInitiative(myCharacters.iCurrentInitiative);
        }
        private void Lock10_Clicked(object sender, RoutedEventArgs e)
        {
            if (Lock10.IsChecked == true)
            {
                if (cbDMMode.IsChecked == false)
                    spTracker10.Visibility = Visibility.Hidden;
                myCharacters.Attribs[9].Lock = true;
            }
            else
            {
                spTracker10.Visibility = Visibility.Visible;
                myCharacters.Attribs[9].Lock = false;
            }
        }


        private void Condition10a_DropDownClosed(object sender, EventArgs e)
        {
            if (Condition10a.Text == "Normal")
            {
                Condition10b.Visibility = Visibility.Hidden;
                borderCharacter10.Background = Brushes.White;
            }
            else if (Condition10a.Text == "Dead")
            {
                Condition10b.Visibility = Visibility.Hidden;
                borderCharacter10.Background = Brushes.LightGray;
            }
            else
            {
                Condition10b.Visibility = Visibility.Visible;
                borderCharacter10.Background = Brushes.White;
            }

            SetInitiative(myCharacters.iCurrentInitiative);
        }
        private void btnAddDamage10_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int iTotalDamage = Int32.Parse(txtTotalDamage10.Text);
                iTotalDamage = iTotalDamage + Int32.Parse(txtAddDamageAmount10.Text);
                txtTotalDamage10.Text = iTotalDamage.ToString();
                txtAddDamageAmount10.Text = "";
            }
            catch (Exception ex)
            {

            }
        }

        private void btnSubtractDamage10_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int iTotalDamage = Int32.Parse(txtTotalDamage10.Text);
                iTotalDamage = iTotalDamage - Int32.Parse(txtAddDamageAmount10.Text);
                if (iTotalDamage > 0)
                {
                    txtTotalDamage10.Text = iTotalDamage.ToString();
                }
                else
                {
                    txtTotalDamage10.Text = "0";
                    Condition10a.Text = "Dead";
                    borderCharacter10.Background = Brushes.LightGray;
                }
                txtAddDamageAmount10.Text = "";
            }
            catch (Exception ex)
            {

            }
        }

        private void txtInit10_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtInit10.SelectionLength == 0)
                txtInit10.SelectAll();
        }

        private void txtACLow10_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtACLow10.SelectionLength == 0)
                txtACLow10.SelectAll();
        }

        private void txtACHigh10_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtACHigh10.SelectionLength == 0)
                txtACHigh10.SelectAll();
        }

        private void txtTotalDamage10_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtTotalDamage10.SelectionLength == 0)
                txtTotalDamage10.SelectAll();
        }

        private void txtAddDamageAmount10_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtAddDamageAmount10.SelectionLength == 0)
                txtAddDamageAmount10.SelectAll();
        }
        private void updateData10()
        {
            //Visibility is updated by the delete function
            myCharacters.Attribs[9].Initiative = txtInitiative10.Text;
            myCharacters.Attribs[9].Name = txtName10.Text;
            //Lock is updated when it changes
            myCharacters.Attribs[9].InitRoll = txtInit10.Text;
            myCharacters.Attribs[9].ACLow = txtACLow10.Text;
            myCharacters.Attribs[9].ACHigh = txtACHigh10.Text;
            myCharacters.Attribs[9].HP = txtTotalDamage10.Text;
            myCharacters.Attribs[9].ConditionA = Condition10a.Text;
            myCharacters.Attribs[9].ConditionB = Condition10b.Text;
        }
        #endregion

        //**********************************************************************************************************************
        #region "Character 11"

        private void lblAC11_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (cbDMMode.IsChecked == false)
            {
                if (Lock1.IsChecked == false)
                    txtACLow1.Text = txtACLow11.Text;
                if (Lock2.IsChecked == false)
                    txtACLow2.Text = txtACLow11.Text;
                if (Lock3.IsChecked == false)
                    txtACLow3.Text = txtACLow11.Text;
                if (Lock4.IsChecked == false)
                    txtACLow4.Text = txtACLow11.Text;
                if (Lock5.IsChecked == false)
                    txtACLow5.Text = txtACLow11.Text;
                if (Lock6.IsChecked == false)
                    txtACLow6.Text = txtACLow11.Text;
                if (Lock7.IsChecked == false)
                    txtACLow7.Text = txtACLow11.Text;
                if (Lock8.IsChecked == false)
                    txtACLow8.Text = txtACLow11.Text;
                if (Lock9.IsChecked == false)
                    txtACLow9.Text = txtACLow11.Text;
                if (Lock10.IsChecked == false)
                    txtACLow10.Text = txtACLow11.Text;
                if (Lock12.IsChecked == false)
                    txtACLow12.Text = txtACLow11.Text;
                if (Lock13.IsChecked == false)
                    txtACLow13.Text = txtACLow11.Text;
                if (Lock14.IsChecked == false)
                    txtACLow14.Text = txtACLow11.Text;
                if (Lock15.IsChecked == false)
                    txtACLow15.Text = txtACLow11.Text;

                if (Lock1.IsChecked == false)
                    txtACHigh1.Text = txtACHigh11.Text;
                if (Lock2.IsChecked == false)
                    txtACHigh2.Text = txtACHigh11.Text;
                if (Lock3.IsChecked == false)
                    txtACHigh3.Text = txtACHigh11.Text;
                if (Lock4.IsChecked == false)
                    txtACHigh4.Text = txtACHigh11.Text;
                if (Lock5.IsChecked == false)
                    txtACHigh5.Text = txtACHigh11.Text;
                if (Lock6.IsChecked == false)
                    txtACHigh6.Text = txtACHigh11.Text;
                if (Lock7.IsChecked == false)
                    txtACHigh7.Text = txtACHigh11.Text;
                if (Lock8.IsChecked == false)
                    txtACHigh8.Text = txtACHigh11.Text;
                if (Lock9.IsChecked == false)
                    txtACHigh9.Text = txtACHigh11.Text;
                if (Lock10.IsChecked == false)
                    txtACHigh10.Text = txtACHigh11.Text;
                if (Lock12.IsChecked == false)
                    txtACHigh12.Text = txtACHigh11.Text;
                if (Lock13.IsChecked == false)
                    txtACHigh13.Text = txtACHigh11.Text;
                if (Lock14.IsChecked == false)
                    txtACHigh14.Text = txtACHigh11.Text;
                if (Lock15.IsChecked == false)
                    txtACHigh15.Text = txtACHigh11.Text;
            }
        }

        private void Condition11a_DropDownClosed_1(object sender, EventArgs e)
        {
            if (Condition11a.Text == "Normal")
            {
                Condition11b.Visibility = Visibility.Hidden;
                borderCharacter11.Background = Brushes.White;
            }
            else if (Condition11a.Text == "Dead")
            {
                Condition11b.Visibility = Visibility.Hidden;
                borderCharacter11.Background = Brushes.LightGray;
            }
            else
            {
                Condition11b.Visibility = Visibility.Visible;
                borderCharacter11.Background = Brushes.White;
            }

            SetInitiative(myCharacters.iCurrentInitiative);
        }

        private void btnUp11_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Character tempCharacters = new Character();
            updateData();

            tempCharacters.Attribs[9] = myCharacters.Attribs[9];
            myCharacters.Attribs[9] = myCharacters.Attribs[10];
            myCharacters.Attribs[10] = tempCharacters.Attribs[9];
            myCharacters.resetInitiatives();

            updateScreenValues();
            showActive();

            SetInitiative(myCharacters.iCurrentInitiative);
        }

        private void btnDown11_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Character tempCharacters = new Character();
            updateData();

            if (myCharacters.Attribs[11].Visible == true)
            {
                tempCharacters.Attribs[10] = myCharacters.Attribs[10];
                myCharacters.Attribs[10] = myCharacters.Attribs[11];
                myCharacters.Attribs[11] = tempCharacters.Attribs[10];
                myCharacters.resetInitiatives();

                updateScreenValues();
                showActive();

                SetInitiative(myCharacters.iCurrentInitiative);
            }
        }

        private void btnDelete11_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Character tempCharacters = new Character();

            updateData();
            tempCharacters = myCharacters;
            for (int x = 10; x <= myCharacters.iTotalPlayers - 1; x++)
            {
                myCharacters.Attribs[x] = tempCharacters.Attribs[x + 1];
            }
            myCharacters.clearCharacter(myCharacters.iTotalPlayers);  //delete bottom entry
            myCharacters.countTotalPlayers();
            myCharacters.resetInitiatives();

            updateScreenValues();
            showActive();

            SetInitiative(myCharacters.iCurrentInitiative);
        }
        private void Lock11_Clicked(object sender, RoutedEventArgs e)
        {
            if (Lock11.IsChecked == true)
            {
                if (cbDMMode.IsChecked == false)
                    spTracker11.Visibility = Visibility.Hidden;
                myCharacters.Attribs[10].Lock = true;
            }
            else
            {
                spTracker11.Visibility = Visibility.Visible;
                myCharacters.Attribs[10].Lock = false;
            }
        }


        private void Condition11a_DropDownClosed(object sender, EventArgs e)
        {
            if (Condition11a.Text == "Normal")
            {
                Condition11b.Visibility = Visibility.Hidden;
                borderCharacter11.Background = Brushes.White;
            }
            else if (Condition11a.Text == "Dead")
            {
                Condition11b.Visibility = Visibility.Hidden;
                borderCharacter11.Background = Brushes.LightGray;
            }
            else
            {
                Condition11b.Visibility = Visibility.Visible;
                borderCharacter11.Background = Brushes.White;
            }

            SetInitiative(myCharacters.iCurrentInitiative);
        }
        private void btnAddDamage11_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int iTotalDamage = Int32.Parse(txtTotalDamage11.Text);
                iTotalDamage = iTotalDamage + Int32.Parse(txtAddDamageAmount11.Text);
                txtTotalDamage11.Text = iTotalDamage.ToString();
                txtAddDamageAmount11.Text = "";
            }
            catch (Exception ex)
            {

            }
        }

        private void btnSubtractDamage11_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int iTotalDamage = Int32.Parse(txtTotalDamage11.Text);
                iTotalDamage = iTotalDamage - Int32.Parse(txtAddDamageAmount11.Text);
                if (iTotalDamage > 0)
                {
                    txtTotalDamage11.Text = iTotalDamage.ToString();
                }
                else
                {
                    txtTotalDamage11.Text = "0";
                    Condition11a.Text = "Dead";
                    borderCharacter11.Background = Brushes.LightGray;
                }
                txtAddDamageAmount11.Text = "";
            }
            catch (Exception ex)
            {

            }
        }

        private void txtInit11_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtInit11.SelectionLength == 0)
                txtInit11.SelectAll();
        }

        private void txtACLow11_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtACLow11.SelectionLength == 0)
                txtACLow11.SelectAll();
        }

        private void txtACHigh11_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtACHigh11.SelectionLength == 0)
                txtACHigh11.SelectAll();
        }

        private void txtTotalDamage11_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtTotalDamage11.SelectionLength == 0)
                txtTotalDamage11.SelectAll();
        }

        private void txtAddDamageAmount11_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtAddDamageAmount11.SelectionLength == 0)
                txtAddDamageAmount11.SelectAll();
        }
        private void updateData11()
        {
            //Visibility is updated by the delete function
            myCharacters.Attribs[10].Initiative = txtInitiative11.Text;
            myCharacters.Attribs[10].Name = txtName11.Text;
            //Lock is updated when it changes
            myCharacters.Attribs[10].InitRoll = txtInit11.Text;
            myCharacters.Attribs[10].ACLow = txtACLow11.Text;
            myCharacters.Attribs[10].ACHigh = txtACHigh11.Text;
            myCharacters.Attribs[10].HP = txtTotalDamage11.Text;
            myCharacters.Attribs[10].ConditionA = Condition11a.Text;
            myCharacters.Attribs[10].ConditionB = Condition11b.Text;
        }
        #endregion

        //**********************************************************************************************************************
        #region "Character 12"

        private void lblAC12_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (cbDMMode.IsChecked == false)
            {
                if (Lock1.IsChecked == false)
                    txtACLow1.Text = txtACLow12.Text;
                if (Lock2.IsChecked == false)
                    txtACLow2.Text = txtACLow12.Text;
                if (Lock3.IsChecked == false)
                    txtACLow3.Text = txtACLow12.Text;
                if (Lock4.IsChecked == false)
                    txtACLow4.Text = txtACLow12.Text;
                if (Lock5.IsChecked == false)
                    txtACLow5.Text = txtACLow12.Text;
                if (Lock6.IsChecked == false)
                    txtACLow6.Text = txtACLow12.Text;
                if (Lock7.IsChecked == false)
                    txtACLow7.Text = txtACLow12.Text;
                if (Lock8.IsChecked == false)
                    txtACLow8.Text = txtACLow12.Text;
                if (Lock9.IsChecked == false)
                    txtACLow9.Text = txtACLow12.Text;
                if (Lock10.IsChecked == false)
                    txtACLow10.Text = txtACLow12.Text;
                if (Lock11.IsChecked == false)
                    txtACLow11.Text = txtACLow12.Text;
                if (Lock13.IsChecked == false)
                    txtACLow13.Text = txtACLow12.Text;
                if (Lock14.IsChecked == false)
                    txtACLow14.Text = txtACLow12.Text;
                if (Lock15.IsChecked == false)
                    txtACLow15.Text = txtACLow12.Text;

                if (Lock1.IsChecked == false)
                    txtACHigh1.Text = txtACHigh12.Text;
                if (Lock2.IsChecked == false)
                    txtACHigh2.Text = txtACHigh12.Text;
                if (Lock3.IsChecked == false)
                    txtACHigh3.Text = txtACHigh12.Text;
                if (Lock4.IsChecked == false)
                    txtACHigh4.Text = txtACHigh12.Text;
                if (Lock5.IsChecked == false)
                    txtACHigh5.Text = txtACHigh12.Text;
                if (Lock6.IsChecked == false)
                    txtACHigh6.Text = txtACHigh12.Text;
                if (Lock7.IsChecked == false)
                    txtACHigh7.Text = txtACHigh12.Text;
                if (Lock8.IsChecked == false)
                    txtACHigh8.Text = txtACHigh12.Text;
                if (Lock9.IsChecked == false)
                    txtACHigh9.Text = txtACHigh12.Text;
                if (Lock10.IsChecked == false)
                    txtACHigh10.Text = txtACHigh12.Text;
                if (Lock11.IsChecked == false)
                    txtACHigh11.Text = txtACHigh12.Text;
                if (Lock13.IsChecked == false)
                    txtACHigh13.Text = txtACHigh12.Text;
                if (Lock14.IsChecked == false)
                    txtACHigh14.Text = txtACHigh12.Text;
                if (Lock15.IsChecked == false)
                    txtACHigh15.Text = txtACHigh12.Text;
            }
        }

        private void Condition12a_DropDownClosed_1(object sender, EventArgs e)
        {
            if (Condition12a.Text == "Normal")
            {
                Condition12b.Visibility = Visibility.Hidden;
                borderCharacter12.Background = Brushes.White;
            }
            else if (Condition12a.Text == "Dead")
            {
                Condition12b.Visibility = Visibility.Hidden;
                borderCharacter12.Background = Brushes.LightGray;
            }
            else
            {
                Condition12b.Visibility = Visibility.Visible;
                borderCharacter12.Background = Brushes.White;
            }

            SetInitiative(myCharacters.iCurrentInitiative);
        }

        private void btnUp12_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Character tempCharacters = new Character();
            updateData();

            tempCharacters.Attribs[10] = myCharacters.Attribs[10];
            myCharacters.Attribs[10] = myCharacters.Attribs[11];
            myCharacters.Attribs[11] = tempCharacters.Attribs[10];
            myCharacters.resetInitiatives();

            updateScreenValues();
            showActive();

            SetInitiative(myCharacters.iCurrentInitiative);
        }

        private void btnDown12_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Character tempCharacters = new Character();
            updateData();

            if (myCharacters.Attribs[12].Visible == true)
            {
                tempCharacters.Attribs[11] = myCharacters.Attribs[11];
                myCharacters.Attribs[11] = myCharacters.Attribs[12];
                myCharacters.Attribs[12] = tempCharacters.Attribs[11];
                myCharacters.resetInitiatives();

                updateScreenValues();
                showActive();

                SetInitiative(myCharacters.iCurrentInitiative);
            }
        }

        private void btnDelete12_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Character tempCharacters = new Character();

            updateData();
            tempCharacters = myCharacters;
            for (int x = 11; x <= myCharacters.iTotalPlayers - 1; x++)
            {
                myCharacters.Attribs[x] = tempCharacters.Attribs[x + 1];
            }
            myCharacters.clearCharacter(myCharacters.iTotalPlayers);  //delete bottom entry
            myCharacters.countTotalPlayers();
            myCharacters.resetInitiatives();

            updateScreenValues();
            showActive();

            SetInitiative(myCharacters.iCurrentInitiative);
        }
        private void Lock12_Clicked(object sender, RoutedEventArgs e)
        {
            if (Lock12.IsChecked == true)
            {
                if (cbDMMode.IsChecked == false)
                    spTracker12.Visibility = Visibility.Hidden;
                myCharacters.Attribs[11].Lock = true;
            }
            else
            {
                spTracker12.Visibility = Visibility.Visible;
                myCharacters.Attribs[11].Lock = false;
            }
        }


        private void Condition12a_DropDownClosed(object sender, EventArgs e)
        {
            if (Condition12a.Text == "Normal")
            {
                Condition12b.Visibility = Visibility.Hidden;
                borderCharacter12.Background = Brushes.White;
            }
            else if (Condition12a.Text == "Dead")
            {
                Condition12b.Visibility = Visibility.Hidden;
                borderCharacter12.Background = Brushes.LightGray;
            }
            else
            {
                Condition12b.Visibility = Visibility.Visible;
                borderCharacter12.Background = Brushes.White;
            }

        }
        private void btnAddDamage12_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int iTotalDamage = Int32.Parse(txtTotalDamage12.Text);
                iTotalDamage = iTotalDamage + Int32.Parse(txtAddDamageAmount12.Text);
                txtTotalDamage12.Text = iTotalDamage.ToString();
                txtAddDamageAmount12.Text = "";
            }
            catch (Exception ex)
            {

            }
        }

        private void btnSubtractDamage12_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int iTotalDamage = Int32.Parse(txtTotalDamage12.Text);
                iTotalDamage = iTotalDamage - Int32.Parse(txtAddDamageAmount12.Text);
                if (iTotalDamage > 0)
                {
                    txtTotalDamage12.Text = iTotalDamage.ToString();
                }
                else
                {
                    txtTotalDamage12.Text = "0";
                    Condition12a.Text = "Dead";
                    borderCharacter12.Background = Brushes.LightGray;
                }
                txtAddDamageAmount12.Text = "";
            }
            catch (Exception ex)
            {

            }
        }

        private void txtInit12_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtInit12.SelectionLength == 0)
                txtInit12.SelectAll();
        }

        private void txtACLow12_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtACLow12.SelectionLength == 0)
                txtACLow12.SelectAll();
        }

        private void txtACHigh12_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtACHigh12.SelectionLength == 0)
                txtACHigh12.SelectAll();
        }

        private void txtTotalDamage12_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtTotalDamage12.SelectionLength == 0)
                txtTotalDamage12.SelectAll();
        }

        private void txtAddDamageAmount12_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtAddDamageAmount12.SelectionLength == 0)
                txtAddDamageAmount12.SelectAll();
        }
        private void updateData12()
        {
            //Visibility is updated by the delete function
            myCharacters.Attribs[11].Initiative = txtInitiative12.Text;
            myCharacters.Attribs[11].Name = txtName12.Text;
            //Lock is updated when it changes
            myCharacters.Attribs[11].InitRoll = txtInit12.Text;
            myCharacters.Attribs[11].ACLow = txtACLow12.Text;
            myCharacters.Attribs[11].ACHigh = txtACHigh12.Text;
            myCharacters.Attribs[11].HP = txtTotalDamage12.Text;
            myCharacters.Attribs[11].ConditionA = Condition12a.Text;
            myCharacters.Attribs[11].ConditionB = Condition12b.Text;
        }
        #endregion

        //**********************************************************************************************************************
        #region "Character 13"

        private void lblAC13_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (cbDMMode.IsChecked == false)
            {
                if (Lock1.IsChecked == false)
                    txtACLow1.Text = txtACLow13.Text;
                if (Lock2.IsChecked == false)
                    txtACLow2.Text = txtACLow13.Text;
                if (Lock3.IsChecked == false)
                    txtACLow3.Text = txtACLow13.Text;
                if (Lock4.IsChecked == false)
                    txtACLow4.Text = txtACLow13.Text;
                if (Lock5.IsChecked == false)
                    txtACLow5.Text = txtACLow13.Text;
                if (Lock6.IsChecked == false)
                    txtACLow6.Text = txtACLow13.Text;
                if (Lock7.IsChecked == false)
                    txtACLow7.Text = txtACLow13.Text;
                if (Lock8.IsChecked == false)
                    txtACLow8.Text = txtACLow13.Text;
                if (Lock9.IsChecked == false)
                    txtACLow9.Text = txtACLow13.Text;
                if (Lock10.IsChecked == false)
                    txtACLow10.Text = txtACLow13.Text;
                if (Lock11.IsChecked == false)
                    txtACLow11.Text = txtACLow13.Text;
                if (Lock12.IsChecked == false)
                    txtACLow12.Text = txtACLow13.Text;
                if (Lock14.IsChecked == false)
                    txtACLow14.Text = txtACLow13.Text;
                if (Lock15.IsChecked == false)
                    txtACLow15.Text = txtACLow13.Text;

                if (Lock1.IsChecked == false)
                    txtACHigh1.Text = txtACHigh13.Text;
                if (Lock2.IsChecked == false)
                    txtACHigh2.Text = txtACHigh13.Text;
                if (Lock3.IsChecked == false)
                    txtACHigh3.Text = txtACHigh13.Text;
                if (Lock4.IsChecked == false)
                    txtACHigh4.Text = txtACHigh13.Text;
                if (Lock5.IsChecked == false)
                    txtACHigh5.Text = txtACHigh13.Text;
                if (Lock6.IsChecked == false)
                    txtACHigh6.Text = txtACHigh13.Text;
                if (Lock7.IsChecked == false)
                    txtACHigh7.Text = txtACHigh13.Text;
                if (Lock8.IsChecked == false)
                    txtACHigh8.Text = txtACHigh13.Text;
                if (Lock9.IsChecked == false)
                    txtACHigh9.Text = txtACHigh13.Text;
                if (Lock10.IsChecked == false)
                    txtACHigh10.Text = txtACHigh13.Text;
                if (Lock11.IsChecked == false)
                    txtACHigh11.Text = txtACHigh13.Text;
                if (Lock12.IsChecked == false)
                    txtACHigh12.Text = txtACHigh13.Text;
                if (Lock14.IsChecked == false)
                    txtACHigh14.Text = txtACHigh13.Text;
                if (Lock15.IsChecked == false)
                    txtACHigh15.Text = txtACHigh13.Text;
            }
        }

        private void Condition13a_DropDownClosed_1(object sender, EventArgs e)
        {
            if (Condition13a.Text == "Normal")
            {
                Condition13b.Visibility = Visibility.Hidden;
                borderCharacter13.Background = Brushes.White;
            }
            else if (Condition13a.Text == "Dead")
            {
                Condition13b.Visibility = Visibility.Hidden;
                borderCharacter13.Background = Brushes.LightGray;
            }
            else
            {
                Condition13b.Visibility = Visibility.Visible;
                borderCharacter13.Background = Brushes.White;
            }

            SetInitiative(myCharacters.iCurrentInitiative);
        }
        private void btnUp13_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Character tempCharacters = new Character();
            updateData();

            tempCharacters.Attribs[11] = myCharacters.Attribs[11];
            myCharacters.Attribs[11] = myCharacters.Attribs[12];
            myCharacters.Attribs[12] = tempCharacters.Attribs[11];
            myCharacters.resetInitiatives();

            updateScreenValues();
            showActive();

            SetInitiative(myCharacters.iCurrentInitiative);
        }

        private void btnDown13_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Character tempCharacters = new Character();
            updateData();

            if (myCharacters.Attribs[13].Visible == true)
            {
                tempCharacters.Attribs[12] = myCharacters.Attribs[12];
                myCharacters.Attribs[12] = myCharacters.Attribs[13];
                myCharacters.Attribs[13] = tempCharacters.Attribs[12];
                myCharacters.resetInitiatives();

                updateScreenValues();
                showActive();

                SetInitiative(myCharacters.iCurrentInitiative);
            }
        }

        private void btnDelete13_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Character tempCharacters = new Character();

            updateData();
            tempCharacters = myCharacters;
            for (int x = 12; x <= myCharacters.iTotalPlayers - 1; x++)
            {
                myCharacters.Attribs[x] = tempCharacters.Attribs[x + 1];
            }
            myCharacters.clearCharacter(myCharacters.iTotalPlayers);  //delete bottom entry
            myCharacters.countTotalPlayers();
            myCharacters.resetInitiatives();

            updateScreenValues();
            showActive();

            SetInitiative(myCharacters.iCurrentInitiative);
        }
        private void Lock13_Clicked(object sender, RoutedEventArgs e)
        {
            if (Lock13.IsChecked == true)
            {
                if (cbDMMode.IsChecked == false)
                    spTracker13.Visibility = Visibility.Hidden;
                myCharacters.Attribs[12].Lock = true;
            }
            else
            {
                spTracker13.Visibility = Visibility.Visible;
                myCharacters.Attribs[12].Lock = false;
            }
        }


        private void Condition13a_DropDownClosed(object sender, EventArgs e)
        {
            if (Condition13a.Text == "Normal")
            {
                Condition13b.Visibility = Visibility.Hidden;
                borderCharacter13.Background = Brushes.White;
            }
            else if (Condition13a.Text == "Dead")
            {
                Condition13b.Visibility = Visibility.Hidden;
                borderCharacter13.Background = Brushes.LightGray;
            }
            else
            {
                Condition13b.Visibility = Visibility.Visible;
                borderCharacter13.Background = Brushes.White;
            }

        }
        private void btnAddDamage13_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int iTotalDamage = Int32.Parse(txtTotalDamage13.Text);
                iTotalDamage = iTotalDamage + Int32.Parse(txtAddDamageAmount13.Text);
                txtTotalDamage13.Text = iTotalDamage.ToString();
                txtAddDamageAmount13.Text = "";
            }
            catch (Exception ex)
            {

            }
        }

        private void btnSubtractDamage13_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int iTotalDamage = Int32.Parse(txtTotalDamage13.Text);
                iTotalDamage = iTotalDamage - Int32.Parse(txtAddDamageAmount13.Text);
                if (iTotalDamage > 0)
                {
                    txtTotalDamage13.Text = iTotalDamage.ToString();
                }
                else
                {
                    txtTotalDamage13.Text = "0";
                    Condition13a.Text = "Dead";
                    borderCharacter13.Background = Brushes.LightGray;
                }
                txtAddDamageAmount13.Text = "";
            }
            catch (Exception ex)
            {

            }
        }

        private void txtInit13_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtInit13.SelectionLength == 0)
                txtInit13.SelectAll();
        }

        private void txtACLow13_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtACLow13.SelectionLength == 0)
                txtACLow13.SelectAll();
        }

        private void txtACHigh13_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtACHigh13.SelectionLength == 0)
                txtACHigh13.SelectAll();
        }

        private void txtTotalDamage13_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtTotalDamage13.SelectionLength == 0)
                txtTotalDamage13.SelectAll();
        }

        private void txtAddDamageAmount13_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtAddDamageAmount13.SelectionLength == 0)
                txtAddDamageAmount13.SelectAll();
        }
        private void updateData13()
        {
            //Visibility is updated by the delete function
            myCharacters.Attribs[12].Initiative = txtInitiative13.Text;
            myCharacters.Attribs[12].Name = txtName13.Text;
            //Lock is updated when it changes
            myCharacters.Attribs[12].InitRoll = txtInit13.Text;
            myCharacters.Attribs[12].ACLow = txtACLow13.Text;
            myCharacters.Attribs[12].ACHigh = txtACHigh13.Text;
            myCharacters.Attribs[12].HP = txtTotalDamage13.Text;
            myCharacters.Attribs[12].ConditionA = Condition13a.Text;
            myCharacters.Attribs[12].ConditionB = Condition13b.Text;
        }
        #endregion

        //**********************************************************************************************************************
        #region "Character 14"

        private void lblAC14_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (cbDMMode.IsChecked == false)
            {
                if (Lock1.IsChecked == false)
                    txtACLow1.Text = txtACLow14.Text;
                if (Lock2.IsChecked == false)
                    txtACLow2.Text = txtACLow14.Text;
                if (Lock3.IsChecked == false)
                    txtACLow3.Text = txtACLow14.Text;
                if (Lock4.IsChecked == false)
                    txtACLow4.Text = txtACLow14.Text;
                if (Lock5.IsChecked == false)
                    txtACLow5.Text = txtACLow14.Text;
                if (Lock6.IsChecked == false)
                    txtACLow6.Text = txtACLow14.Text;
                if (Lock7.IsChecked == false)
                    txtACLow7.Text = txtACLow14.Text;
                if (Lock8.IsChecked == false)
                    txtACLow8.Text = txtACLow14.Text;
                if (Lock9.IsChecked == false)
                    txtACLow9.Text = txtACLow14.Text;
                if (Lock10.IsChecked == false)
                    txtACLow10.Text = txtACLow14.Text;
                if (Lock11.IsChecked == false)
                    txtACLow11.Text = txtACLow14.Text;
                if (Lock12.IsChecked == false)
                    txtACLow12.Text = txtACLow14.Text;
                if (Lock13.IsChecked == false)
                    txtACLow13.Text = txtACLow14.Text;
                if (Lock15.IsChecked == false)
                    txtACLow15.Text = txtACLow14.Text;

                if (Lock1.IsChecked == false)
                    txtACHigh1.Text = txtACHigh14.Text;
                if (Lock2.IsChecked == false)
                    txtACHigh2.Text = txtACHigh14.Text;
                if (Lock3.IsChecked == false)
                    txtACHigh3.Text = txtACHigh14.Text;
                if (Lock4.IsChecked == false)
                    txtACHigh4.Text = txtACHigh14.Text;
                if (Lock5.IsChecked == false)
                    txtACHigh5.Text = txtACHigh14.Text;
                if (Lock6.IsChecked == false)
                    txtACHigh6.Text = txtACHigh14.Text;
                if (Lock7.IsChecked == false)
                    txtACHigh7.Text = txtACHigh14.Text;
                if (Lock8.IsChecked == false)
                    txtACHigh8.Text = txtACHigh14.Text;
                if (Lock9.IsChecked == false)
                    txtACHigh9.Text = txtACHigh14.Text;
                if (Lock10.IsChecked == false)
                    txtACHigh10.Text = txtACHigh14.Text;
                if (Lock11.IsChecked == false)
                    txtACHigh11.Text = txtACHigh14.Text;
                if (Lock12.IsChecked == false)
                    txtACHigh12.Text = txtACHigh14.Text;
                if (Lock13.IsChecked == false)
                    txtACHigh13.Text = txtACHigh14.Text;
                if (Lock15.IsChecked == false)
                    txtACHigh15.Text = txtACHigh14.Text;
            }
        }

        private void Condition14a_DropDownClosed_1(object sender, EventArgs e)
        {
            if (Condition14a.Text == "Normal")
            {
                Condition14b.Visibility = Visibility.Hidden;
                borderCharacter14.Background = Brushes.White;
            }
            else if (Condition14a.Text == "Dead")
            {
                Condition14b.Visibility = Visibility.Hidden;
                borderCharacter14.Background = Brushes.LightGray;
            }
            else
            {
                Condition14b.Visibility = Visibility.Visible;
                borderCharacter14.Background = Brushes.White;
            }

            SetInitiative(myCharacters.iCurrentInitiative);
        }
        private void btnUp14_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Character tempCharacters = new Character();
            updateData();

            tempCharacters.Attribs[12] = myCharacters.Attribs[12];
            myCharacters.Attribs[12] = myCharacters.Attribs[13];
            myCharacters.Attribs[13] = tempCharacters.Attribs[12];
            myCharacters.resetInitiatives();

            updateScreenValues();
            showActive();

            SetInitiative(myCharacters.iCurrentInitiative);
        }

        private void btnDown14_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Character tempCharacters = new Character();
            updateData();

            if (myCharacters.Attribs[14].Visible == true)
            {
                tempCharacters.Attribs[13] = myCharacters.Attribs[13];
                myCharacters.Attribs[13] = myCharacters.Attribs[14];
                myCharacters.Attribs[14] = tempCharacters.Attribs[13];
                myCharacters.resetInitiatives();

                updateScreenValues();
                showActive();

                SetInitiative(myCharacters.iCurrentInitiative);
            }
        }

        private void btnDelete14_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Character tempCharacters = new Character();

            updateData();
            tempCharacters = myCharacters;
            for (int x = 13; x <= myCharacters.iTotalPlayers - 1; x++)
            {
                myCharacters.Attribs[x] = tempCharacters.Attribs[x + 1];
            }
            myCharacters.clearCharacter(myCharacters.iTotalPlayers);  //delete bottom entry
            myCharacters.countTotalPlayers();
            myCharacters.resetInitiatives();

            updateScreenValues();
            showActive();

            SetInitiative(myCharacters.iCurrentInitiative);
        }
        private void Lock14_Clicked(object sender, RoutedEventArgs e)
        {
            if (Lock14.IsChecked == true)
            {
                if (cbDMMode.IsChecked == false)
                    spTracker14.Visibility = Visibility.Hidden;
                myCharacters.Attribs[13].Lock = true;
            }
            else
            {
                spTracker14.Visibility = Visibility.Visible;
                myCharacters.Attribs[13].Lock = false;
            }
        }


        private void Condition14a_DropDownClosed(object sender, EventArgs e)
        {
            if (Condition14a.Text == "Normal")
            {
                Condition14b.Visibility = Visibility.Hidden;
                borderCharacter14.Background = Brushes.White;
            }
            else if (Condition14a.Text == "Dead")
            {
                Condition14b.Visibility = Visibility.Hidden;
                borderCharacter14.Background = Brushes.LightGray;
            }
            else
            {
                Condition14b.Visibility = Visibility.Visible;
                borderCharacter14.Background = Brushes.White;
            }

        }
        private void btnAddDamage14_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int iTotalDamage = Int32.Parse(txtTotalDamage14.Text);
                iTotalDamage = iTotalDamage + Int32.Parse(txtAddDamageAmount14.Text);
                txtTotalDamage14.Text = iTotalDamage.ToString();
                txtAddDamageAmount14.Text = "";
            }
            catch (Exception ex)
            {

            }
        }

        private void btnSubtractDamage14_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int iTotalDamage = Int32.Parse(txtTotalDamage14.Text);
                iTotalDamage = iTotalDamage - Int32.Parse(txtAddDamageAmount14.Text);
                if (iTotalDamage > 0)
                {
                    txtTotalDamage14.Text = iTotalDamage.ToString();
                }
                else
                {
                    txtTotalDamage14.Text = "0";
                    Condition14a.Text = "Dead";
                    borderCharacter14.Background = Brushes.LightGray;
                }
                txtAddDamageAmount14.Text = "";
            }
            catch (Exception ex)
            {

            }
        }

        private void txtInit14_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtInit14.SelectionLength == 0)
                txtInit14.SelectAll();
        }

        private void txtACLow14_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtACLow14.SelectionLength == 0)
                txtACLow14.SelectAll();
        }

        private void txtACHigh14_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtACHigh14.SelectionLength == 0)
                txtACHigh14.SelectAll();
        }

        private void txtTotalDamage14_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtTotalDamage14.SelectionLength == 0)
                txtTotalDamage14.SelectAll();
        }

        private void txtAddDamageAmount14_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtAddDamageAmount14.SelectionLength == 0)
                txtAddDamageAmount14.SelectAll();
        }
        private void updateData14()
        {
            //Visibility is updated by the delete function
            myCharacters.Attribs[13].Initiative = txtInitiative14.Text;
            myCharacters.Attribs[13].Name = txtName14.Text;
            //Lock is updated when it changes
            myCharacters.Attribs[13].InitRoll = txtInit14.Text;
            myCharacters.Attribs[13].ACLow = txtACLow14.Text;
            myCharacters.Attribs[13].ACHigh = txtACHigh14.Text;
            myCharacters.Attribs[13].HP = txtTotalDamage14.Text;
            myCharacters.Attribs[13].ConditionA = Condition14a.Text;
            myCharacters.Attribs[13].ConditionB = Condition14b.Text;
        }
        #endregion

        //**********************************************************************************************************************
        #region "Character 15"

        private void lblAC15_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (cbDMMode.IsChecked == false)
            {
                if (Lock1.IsChecked == false)
                    txtACLow1.Text = txtACLow15.Text;
                if (Lock2.IsChecked == false)
                    txtACLow2.Text = txtACLow15.Text;
                if (Lock3.IsChecked == false)
                    txtACLow3.Text = txtACLow15.Text;
                if (Lock4.IsChecked == false)
                    txtACLow4.Text = txtACLow15.Text;
                if (Lock5.IsChecked == false)
                    txtACLow5.Text = txtACLow15.Text;
                if (Lock6.IsChecked == false)
                    txtACLow6.Text = txtACLow15.Text;
                if (Lock7.IsChecked == false)
                    txtACLow7.Text = txtACLow15.Text;
                if (Lock8.IsChecked == false)
                    txtACLow8.Text = txtACLow15.Text;
                if (Lock9.IsChecked == false)
                    txtACLow9.Text = txtACLow15.Text;
                if (Lock10.IsChecked == false)
                    txtACLow10.Text = txtACLow15.Text;
                if (Lock11.IsChecked == false)
                    txtACLow11.Text = txtACLow15.Text;
                if (Lock12.IsChecked == false)
                    txtACLow12.Text = txtACLow15.Text;
                if (Lock13.IsChecked == false)
                    txtACLow13.Text = txtACLow15.Text;
                if (Lock14.IsChecked == false)
                    txtACLow14.Text = txtACLow15.Text;

                if (Lock1.IsChecked == false)
                    txtACHigh1.Text = txtACHigh15.Text;
                if (Lock2.IsChecked == false)
                    txtACHigh2.Text = txtACHigh15.Text;
                if (Lock3.IsChecked == false)
                    txtACHigh3.Text = txtACHigh15.Text;
                if (Lock4.IsChecked == false)
                    txtACHigh4.Text = txtACHigh15.Text;
                if (Lock5.IsChecked == false)
                    txtACHigh5.Text = txtACHigh15.Text;
                if (Lock6.IsChecked == false)
                    txtACHigh6.Text = txtACHigh15.Text;
                if (Lock7.IsChecked == false)
                    txtACHigh7.Text = txtACHigh15.Text;
                if (Lock8.IsChecked == false)
                    txtACHigh8.Text = txtACHigh15.Text;
                if (Lock9.IsChecked == false)
                    txtACHigh9.Text = txtACHigh15.Text;
                if (Lock10.IsChecked == false)
                    txtACHigh10.Text = txtACHigh15.Text;
                if (Lock11.IsChecked == false)
                    txtACHigh11.Text = txtACHigh15.Text;
                if (Lock12.IsChecked == false)
                    txtACHigh12.Text = txtACHigh15.Text;
                if (Lock13.IsChecked == false)
                    txtACHigh13.Text = txtACHigh15.Text;
                if (Lock14.IsChecked == false)
                    txtACHigh14.Text = txtACHigh15.Text;
            }
        }

        private void Condition15a_DropDownClosed_1(object sender, EventArgs e)
        {
            if (Condition15a.Text == "Normal")
            {
                Condition15b.Visibility = Visibility.Hidden;
                borderCharacter15.Background = Brushes.White;
            }
            else if (Condition15a.Text == "Dead")
            {
                Condition15b.Visibility = Visibility.Hidden;
                borderCharacter15.Background = Brushes.LightGray;
            }
            else
            {
                Condition15b.Visibility = Visibility.Visible;
                borderCharacter15.Background = Brushes.White;
            }

            SetInitiative(myCharacters.iCurrentInitiative);
        }
        private void btnUp15_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Character tempCharacters = new Character();
            updateData();

            tempCharacters.Attribs[13] = myCharacters.Attribs[13];
            myCharacters.Attribs[13] = myCharacters.Attribs[14];
            myCharacters.Attribs[14] = tempCharacters.Attribs[13];
            myCharacters.resetInitiatives();

            updateScreenValues();
            showActive();

            SetInitiative(myCharacters.iCurrentInitiative);
        }

        private void btnDown15_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Character tempCharacters = new Character();
            updateData();

            if (myCharacters.Attribs[15].Visible == true)
            {
                tempCharacters.Attribs[14] = myCharacters.Attribs[14];
                myCharacters.Attribs[14] = myCharacters.Attribs[15];
                myCharacters.Attribs[15] = tempCharacters.Attribs[14];
                myCharacters.resetInitiatives();

                updateScreenValues();
                showActive();

                SetInitiative(myCharacters.iCurrentInitiative);
            }
        }

        private void btnDelete15_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Character tempCharacters = new Character();

            updateData();
            tempCharacters = myCharacters;
            for (int x = 14; x <= myCharacters.iTotalPlayers - 1; x++)
            {
                myCharacters.Attribs[x] = tempCharacters.Attribs[x + 1];
            }
            myCharacters.clearCharacter(myCharacters.iTotalPlayers);  //delete bottom entry
            myCharacters.countTotalPlayers();
            myCharacters.resetInitiatives();

            updateScreenValues();
            showActive();

            SetInitiative(myCharacters.iCurrentInitiative);
        }
        private void Lock15_Clicked(object sender, RoutedEventArgs e)
        {
            if (Lock15.IsChecked == true)
            {
                if (cbDMMode.IsChecked == false)
                    spTracker15.Visibility = Visibility.Hidden;
                myCharacters.Attribs[14].Lock = true;
            }
            else
            {
                spTracker15.Visibility = Visibility.Visible;
                myCharacters.Attribs[14].Lock = false;
            }
        }


        private void Condition15a_DropDownClosed(object sender, EventArgs e)
        {
            if (Condition15a.Text == "Normal")
            {
                Condition15b.Visibility = Visibility.Hidden;
                borderCharacter15.Background = Brushes.White;
            }
            else if (Condition15a.Text == "Dead")
            {
                Condition15b.Visibility = Visibility.Hidden;
                borderCharacter15.Background = Brushes.LightGray;
            }
            else
            {
                Condition15b.Visibility = Visibility.Visible;
                borderCharacter15.Background = Brushes.White;
            }

        }
        private void btnAddDamage15_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int iTotalDamage = Int32.Parse(txtTotalDamage15.Text);
                iTotalDamage = iTotalDamage + Int32.Parse(txtAddDamageAmount15.Text);
                txtTotalDamage15.Text = iTotalDamage.ToString();
                txtAddDamageAmount15.Text = "";
            }
            catch (Exception ex)
            {

            }
        }

        private void btnSubtractDamage15_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int iTotalDamage = Int32.Parse(txtTotalDamage15.Text);
                iTotalDamage = iTotalDamage - Int32.Parse(txtAddDamageAmount15.Text);
                if (iTotalDamage > 0)
                {
                    txtTotalDamage15.Text = iTotalDamage.ToString();
                }
                else
                {
                    txtTotalDamage15.Text = "0";
                    Condition15a.Text = "Dead";
                    borderCharacter15.Background = Brushes.LightGray;
                }
                txtAddDamageAmount15.Text = "";
            }
            catch (Exception ex)
            {

            }
        }

        private void txtInit15_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtInit15.SelectionLength == 0)
                txtInit15.SelectAll();
        }

        private void txtACLow15_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtACLow15.SelectionLength == 0)
                txtACLow15.SelectAll();
        }

        private void txtACHigh15_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtACHigh15.SelectionLength == 0)
                txtACHigh15.SelectAll();
        }

        private void txtTotalDamage15_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtTotalDamage15.SelectionLength == 0)
                txtTotalDamage15.SelectAll();
        }

        private void txtAddDamageAmount15_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtAddDamageAmount15.SelectionLength == 0)
                txtAddDamageAmount15.SelectAll();
        }
        private void updateData15()
        {
            //Visibility is updated by the delete function
            myCharacters.Attribs[14].Initiative = txtInitiative15.Text;
            myCharacters.Attribs[14].Name = txtName15.Text;
            //Lock is updated when it changes
            myCharacters.Attribs[14].InitRoll = txtInit15.Text;
            myCharacters.Attribs[14].ACLow = txtACLow15.Text;
            myCharacters.Attribs[14].ACHigh = txtACHigh15.Text;
            myCharacters.Attribs[14].HP = txtTotalDamage15.Text;
            myCharacters.Attribs[14].ConditionA = Condition15a.Text;
            myCharacters.Attribs[14].ConditionB = Condition15b.Text;
        }
        #endregion


        #region "Bottom Buttons"
        private void btnAddCharacter_Click(object sender, RoutedEventArgs e)
        {
            updateData();
            if (myCharacters.iTotalPlayers < myCharacters.iMaxCharacters)
            {
                myCharacters.Attribs[myCharacters.iTotalPlayers].Visible = true;
                myCharacters.Attribs[myCharacters.iTotalPlayers].Name = "Monster" + MonsterNum.ToString();
                if (cbDMMode.IsChecked == true)
                {
                    var rand = new Random();
                    myCharacters.Attribs[myCharacters.iTotalPlayers].InitRoll = rand.Next(21).ToString();
                }
                else
                {
                    myCharacters.Attribs[myCharacters.iTotalPlayers].InitRoll = "0";
                }
                myCharacters.Attribs[myCharacters.iTotalPlayers].ACLow = "0";
                myCharacters.Attribs[myCharacters.iTotalPlayers].ACHigh = "20";
                myCharacters.Attribs[myCharacters.iTotalPlayers].HP = "0";
                myCharacters.Attribs[myCharacters.iTotalPlayers].ConditionA = "Normal";
                myCharacters.Attribs[myCharacters.iTotalPlayers].ConditionB = "";
                myCharacters.countTotalPlayers();
                myCharacters.resetInitiatives();



                updateScreenValues();
                showActive();

                SetInitiative(myCharacters.iCurrentInitiative);
                MonsterNum++;
            }

        }
        private void btnNextInitiative_Click(object sender, RoutedEventArgs e)
        {
            updateData();
            myCharacters.iCurrentInitiative++;
            if (myCharacters.iCurrentInitiative > myCharacters.iTotalPlayers)
            {
                myCharacters.iCurrentInitiative = 1;
                ScrollBar.ScrollToTop();
            }
            else
            {
                ScrollBar.LineDown();
            }

            SetInitiative(myCharacters.iCurrentInitiative);
        }
        private void btnPrevInitiative_Click(object sender, RoutedEventArgs e)
        {
            updateData();
            myCharacters.iCurrentInitiative--;
            if (myCharacters.iCurrentInitiative == 0)
            {
                myCharacters.iCurrentInitiative = myCharacters.iTotalPlayers;
                ScrollBar.ScrollToBottom();
            }
            else
            {
                ScrollBar.LineUp();
            }

            SetInitiative(myCharacters.iCurrentInitiative);
        }

        private void btnSort_Click(object sender, RoutedEventArgs e)
        {
            bool bSwitch = true;
            Character tempCharacters = new Character();

            updateData();
            //bubble sort

            while (bSwitch == true)
            {
                bSwitch = false;
                if (Int32.Parse(myCharacters.Attribs[0].InitRoll) < Int32.Parse(myCharacters.Attribs[1].InitRoll))
                {
                    tempCharacters.Attribs[0] = myCharacters.Attribs[0];
                    myCharacters.Attribs[0] = myCharacters.Attribs[1];
                    myCharacters.Attribs[1] = tempCharacters.Attribs[0];
                    bSwitch = true;
                }
                if (Int32.Parse(myCharacters.Attribs[1].InitRoll) < Int32.Parse(myCharacters.Attribs[2].InitRoll))
                {
                    tempCharacters.Attribs[1] = myCharacters.Attribs[1];
                    myCharacters.Attribs[1] = myCharacters.Attribs[2];
                    myCharacters.Attribs[2] = tempCharacters.Attribs[1];
                    bSwitch = true;
                }
                if (Int32.Parse(myCharacters.Attribs[2].InitRoll) < Int32.Parse(myCharacters.Attribs[3].InitRoll))
                {
                    tempCharacters.Attribs[2] = myCharacters.Attribs[2];
                    myCharacters.Attribs[2] = myCharacters.Attribs[3];
                    myCharacters.Attribs[3] = tempCharacters.Attribs[2];
                    bSwitch = true;
                }
                if (Int32.Parse(myCharacters.Attribs[3].InitRoll) < Int32.Parse(myCharacters.Attribs[4].InitRoll))
                {
                    tempCharacters.Attribs[3] = myCharacters.Attribs[3];
                    myCharacters.Attribs[3] = myCharacters.Attribs[4];
                    myCharacters.Attribs[4] = tempCharacters.Attribs[3];
                    bSwitch = true;
                }
                if (Int32.Parse(myCharacters.Attribs[4].InitRoll) < Int32.Parse(myCharacters.Attribs[5].InitRoll))
                {
                    tempCharacters.Attribs[4] = myCharacters.Attribs[4];
                    myCharacters.Attribs[4] = myCharacters.Attribs[5];
                    myCharacters.Attribs[5] = tempCharacters.Attribs[4];
                    bSwitch = true;
                }
                if (Int32.Parse(myCharacters.Attribs[5].InitRoll) < Int32.Parse(myCharacters.Attribs[6].InitRoll))
                {
                    tempCharacters.Attribs[5] = myCharacters.Attribs[5];
                    myCharacters.Attribs[5] = myCharacters.Attribs[6];
                    myCharacters.Attribs[6] = tempCharacters.Attribs[5];
                    bSwitch = true;
                }
                if (Int32.Parse(myCharacters.Attribs[6].InitRoll) < Int32.Parse(myCharacters.Attribs[7].InitRoll))
                {
                    tempCharacters.Attribs[6] = myCharacters.Attribs[6];
                    myCharacters.Attribs[6] = myCharacters.Attribs[7];
                    myCharacters.Attribs[7] = tempCharacters.Attribs[6];
                    bSwitch = true;
                }
                if (Int32.Parse(myCharacters.Attribs[7].InitRoll) < Int32.Parse(myCharacters.Attribs[8].InitRoll))
                {
                    tempCharacters.Attribs[7] = myCharacters.Attribs[7];
                    myCharacters.Attribs[7] = myCharacters.Attribs[8];
                    myCharacters.Attribs[8] = tempCharacters.Attribs[7];
                    bSwitch = true;
                }
                if (Int32.Parse(myCharacters.Attribs[8].InitRoll) < Int32.Parse(myCharacters.Attribs[9].InitRoll))
                {
                    tempCharacters.Attribs[8] = myCharacters.Attribs[8];
                    myCharacters.Attribs[8] = myCharacters.Attribs[9];
                    myCharacters.Attribs[9] = tempCharacters.Attribs[8];
                    bSwitch = true;
                }
                if (Int32.Parse(myCharacters.Attribs[9].InitRoll) < Int32.Parse(myCharacters.Attribs[10].InitRoll))
                {
                    tempCharacters.Attribs[9] = myCharacters.Attribs[9];
                    myCharacters.Attribs[9] = myCharacters.Attribs[10];
                    myCharacters.Attribs[10] = tempCharacters.Attribs[9];
                    bSwitch = true;
                }
                if (Int32.Parse(myCharacters.Attribs[10].InitRoll) < Int32.Parse(myCharacters.Attribs[11].InitRoll))
                {
                    tempCharacters.Attribs[10] = myCharacters.Attribs[10];
                    myCharacters.Attribs[10] = myCharacters.Attribs[11];
                    myCharacters.Attribs[11] = tempCharacters.Attribs[10];
                    bSwitch = true;
                }
                if (Int32.Parse(myCharacters.Attribs[11].InitRoll) < Int32.Parse(myCharacters.Attribs[12].InitRoll))
                {
                    tempCharacters.Attribs[11] = myCharacters.Attribs[11];
                    myCharacters.Attribs[11] = myCharacters.Attribs[12];
                    myCharacters.Attribs[12] = tempCharacters.Attribs[11];
                    bSwitch = true;
                }
                if (Int32.Parse(myCharacters.Attribs[12].InitRoll) < Int32.Parse(myCharacters.Attribs[13].InitRoll))
                {
                    tempCharacters.Attribs[12] = myCharacters.Attribs[12];
                    myCharacters.Attribs[12] = myCharacters.Attribs[13];
                    myCharacters.Attribs[13] = tempCharacters.Attribs[12];
                    bSwitch = true;
                }
                if (Int32.Parse(myCharacters.Attribs[13].InitRoll) < Int32.Parse(myCharacters.Attribs[14].InitRoll))
                {
                    tempCharacters.Attribs[13] = myCharacters.Attribs[13];
                    myCharacters.Attribs[13] = myCharacters.Attribs[14];
                    myCharacters.Attribs[14] = tempCharacters.Attribs[13];
                    bSwitch = true;
                }
                if (Int32.Parse(myCharacters.Attribs[14].InitRoll) < Int32.Parse(myCharacters.Attribs[15].InitRoll))
                {
                    tempCharacters.Attribs[14] = myCharacters.Attribs[14];
                    myCharacters.Attribs[14] = myCharacters.Attribs[15];
                    myCharacters.Attribs[15] = tempCharacters.Attribs[14];
                    bSwitch = true;
                }
                if (Int32.Parse(myCharacters.Attribs[15].InitRoll) < Int32.Parse(myCharacters.Attribs[16].InitRoll))
                {
                    tempCharacters.Attribs[15] = myCharacters.Attribs[15];
                    myCharacters.Attribs[15] = myCharacters.Attribs[16];
                    myCharacters.Attribs[16] = tempCharacters.Attribs[15];
                    bSwitch = true;
                }
                if (Int32.Parse(myCharacters.Attribs[16].InitRoll) < Int32.Parse(myCharacters.Attribs[17].InitRoll))
                {
                    tempCharacters.Attribs[16] = myCharacters.Attribs[16];
                    myCharacters.Attribs[16] = myCharacters.Attribs[17];
                    myCharacters.Attribs[17] = tempCharacters.Attribs[16];
                    bSwitch = true;
                }
                if (Int32.Parse(myCharacters.Attribs[17].InitRoll) < Int32.Parse(myCharacters.Attribs[18].InitRoll))
                {
                    tempCharacters.Attribs[17] = myCharacters.Attribs[17];
                    myCharacters.Attribs[17] = myCharacters.Attribs[18];
                    myCharacters.Attribs[18] = tempCharacters.Attribs[17];
                    bSwitch = true;
                }
                if (Int32.Parse(myCharacters.Attribs[18].InitRoll) < Int32.Parse(myCharacters.Attribs[19].InitRoll))
                {
                    tempCharacters.Attribs[18] = myCharacters.Attribs[18];
                    myCharacters.Attribs[18] = myCharacters.Attribs[19];
                    myCharacters.Attribs[19] = tempCharacters.Attribs[18];
                    bSwitch = true;
                }
            }    

            myCharacters.resetInitiatives();
            updateScreenValues();
            showActive();
            myCharacters.iCurrentInitiative = 1;
            SetInitiative(myCharacters.iCurrentInitiative);
            ScrollBar.ScrollToTop();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Character tempCharacters = new Character();

            MonsterNum = 1;

            txtInit1.Text = "0";
            txtInit2.Text = "0";
            txtInit3.Text = "0";
            txtInit4.Text = "0";
            txtInit5.Text = "0";
            txtInit6.Text = "0";
            txtInit7.Text = "0";
            txtInit8.Text = "0";
            txtInit9.Text = "0";
            txtInit10.Text = "0";
            txtInit11.Text = "0";
            txtInit12.Text = "0";
            txtInit13.Text = "0";
            txtInit14.Text = "0";
            txtInit15.Text = "0"; 

            Condition1a.Text = "Normal";
            Condition1b.Text = "";
            Condition1b.Visibility = Visibility.Hidden;
            Condition2a.Text = "Normal";
            Condition2b.Text = "";
            Condition2b.Visibility = Visibility.Hidden;
            Condition3a.Text = "Normal";
            Condition3b.Text = "";
            Condition3b.Visibility = Visibility.Hidden;
            Condition4a.Text = "Normal";
            Condition4b.Text = "";
            Condition4b.Visibility = Visibility.Hidden;
            Condition5a.Text = "Normal";
            Condition5b.Text = "";
            Condition5b.Visibility = Visibility.Hidden;
            Condition6a.Text = "Normal";
            Condition6b.Text = "";
            Condition6b.Visibility = Visibility.Hidden;
            Condition7a.Text = "Normal";
            Condition7b.Text = "";
            Condition7b.Visibility = Visibility.Hidden;
            Condition8a.Text = "Normal";
            Condition8b.Text = "";
            Condition8b.Visibility = Visibility.Hidden;
            Condition9a.Text = "Normal";
            Condition9b.Text = "";
            Condition9b.Visibility = Visibility.Hidden;
            Condition10a.Text = "Normal";
            Condition10b.Text = "";
            Condition10b.Visibility = Visibility.Hidden;
            Condition11a.Text = "Normal";
            Condition11b.Text = "";
            Condition11b.Visibility = Visibility.Hidden;
            Condition12a.Text = "Normal";
            Condition12b.Text = "";
            Condition12b.Visibility = Visibility.Hidden;
            Condition13a.Text = "Normal";
            Condition13b.Text = "";
            Condition13b.Visibility = Visibility.Hidden;
            Condition14a.Text = "Normal";
            Condition14b.Text = "";
            Condition14b.Visibility = Visibility.Hidden;
            Condition15a.Text = "Normal";
            Condition15b.Text = "";
            Condition15b.Visibility = Visibility.Hidden;

            updateData();
            for (int i = 0; i < myCharacters.iTotalPlayers; i++)
            {
                while (myCharacters.Attribs[i].Lock == false && i < myCharacters.iTotalPlayers)
                {
                    tempCharacters = myCharacters;
                    for (int x = i; x < myCharacters.iTotalPlayers - 1; x++)
                    {
                        myCharacters.Attribs[x] = tempCharacters.Attribs[x + 1];
                    }
                    myCharacters.clearCharacter(myCharacters.iTotalPlayers - 1);  //delete bottom entry
                    myCharacters.countTotalPlayers();
                }
            }

            myCharacters.resetInitiatives();
            updateScreenValues();
            showActive();
            myCharacters.iCurrentInitiative = 1;
            SetInitiative(myCharacters.iCurrentInitiative);
            ScrollBar.ScrollToTop();
        }
        private void ClearInitiative()
        {
            if (Condition1a.Text == "Dead")
                borderCharacter1.Background = Brushes.LightGray;
            else
                borderCharacter1.Background = Brushes.White;
            borderCharacter1.BorderThickness = new Thickness(1);

            if (Condition2a.Text == "Dead")
                borderCharacter2.Background = Brushes.LightGray;
            else
                borderCharacter2.Background = Brushes.White;
            borderCharacter2.BorderThickness = new Thickness(1);

            if (Condition3a.Text == "Dead")
                borderCharacter3.Background = Brushes.LightGray;
            else
                borderCharacter3.Background = Brushes.White;
            borderCharacter3.BorderThickness = new Thickness(1);

            if (Condition4a.Text == "Dead")
                borderCharacter4.Background = Brushes.LightGray;
            else
                borderCharacter4.Background = Brushes.White;
            borderCharacter4.BorderThickness = new Thickness(1);

            if (Condition5a.Text == "Dead")
                borderCharacter5.Background = Brushes.LightGray;
            else
                borderCharacter5.Background = Brushes.White;
            borderCharacter5.BorderThickness = new Thickness(1);

            if (Condition6a.Text == "Dead")
                borderCharacter6.Background = Brushes.LightGray;
            else
                borderCharacter6.Background = Brushes.White;
            borderCharacter6.BorderThickness = new Thickness(1);

            if (Condition7a.Text == "Dead")
                borderCharacter7.Background = Brushes.LightGray;
            else
                borderCharacter7.Background = Brushes.White;
            borderCharacter7.BorderThickness = new Thickness(1);

            if (Condition8a.Text == "Dead")
                borderCharacter8.Background = Brushes.LightGray;
            else
                borderCharacter8.Background = Brushes.White;
            borderCharacter8.BorderThickness = new Thickness(1);

            if (Condition9a.Text == "Dead")
                borderCharacter9.Background = Brushes.LightGray;
            else
                borderCharacter9.Background = Brushes.White;
            borderCharacter9.BorderThickness = new Thickness(1);

            if (Condition10a.Text == "Dead")
                borderCharacter10.Background = Brushes.LightGray;
            else
                borderCharacter10.Background = Brushes.White;
            borderCharacter10.BorderThickness = new Thickness(1);

            if (Condition11a.Text == "Dead")
                borderCharacter11.Background = Brushes.LightGray;
            else
                borderCharacter11.Background = Brushes.White;
            borderCharacter11.BorderThickness = new Thickness(1);

            if (Condition12a.Text == "Dead")
                borderCharacter12.Background = Brushes.LightGray;
            else
                borderCharacter12.Background = Brushes.White;
            borderCharacter12.BorderThickness = new Thickness(1);

            if (Condition13a.Text == "Dead")
                borderCharacter13.Background = Brushes.LightGray;
            else
                borderCharacter13.Background = Brushes.White;
            borderCharacter13.BorderThickness = new Thickness(1);

            if (Condition14a.Text == "Dead")
                borderCharacter14.Background = Brushes.LightGray;
            else
                borderCharacter14.Background = Brushes.White;
            borderCharacter14.BorderThickness = new Thickness(1);

            if (Condition15a.Text == "Dead")
                borderCharacter15.Background = Brushes.LightGray;
            else
                borderCharacter15.Background = Brushes.White;
            borderCharacter15.BorderThickness = new Thickness(1);
        }

        private void SetInitiative(int iCurrentInitiative)
        {
            ClearInitiative();
            switch (iCurrentInitiative)
            {
                case 1:
                    borderCharacter1.Background = Brushes.Yellow;
                    borderCharacter1.BorderThickness = new Thickness(2);
                    break;
                case 2:
                    borderCharacter2.Background = Brushes.Yellow;
                    borderCharacter2.BorderThickness = new Thickness(2);
                    break;
                case 3:
                    borderCharacter3.Background = Brushes.Yellow;
                    borderCharacter3.BorderThickness = new Thickness(2);
                    break;
                case 4:
                    borderCharacter4.Background = Brushes.Yellow;
                    borderCharacter4.BorderThickness = new Thickness(2);
                    break;
                case 5:
                    borderCharacter5.Background = Brushes.Yellow;
                    borderCharacter5.BorderThickness = new Thickness(2);
                    break;
                case 6:
                    borderCharacter6.Background = Brushes.Yellow;
                    borderCharacter6.BorderThickness = new Thickness(2);
                    break;
                case 7:
                    borderCharacter7.Background = Brushes.Yellow;
                    borderCharacter7.BorderThickness = new Thickness(2);
                    break;
                case 8:
                    borderCharacter8.Background = Brushes.Yellow;
                    borderCharacter8.BorderThickness = new Thickness(2);
                    break;
                case 9:
                    borderCharacter9.Background = Brushes.Yellow;
                    borderCharacter9.BorderThickness = new Thickness(2);
                    break;
                case 10:
                    borderCharacter10.Background = Brushes.Yellow;
                    borderCharacter10.BorderThickness = new Thickness(2);
                    break;
                case 11:
                    borderCharacter11.Background = Brushes.Yellow;
                    borderCharacter11.BorderThickness = new Thickness(2);
                    break;
                case 12:
                    borderCharacter12.Background = Brushes.Yellow;
                    borderCharacter12.BorderThickness = new Thickness(2);
                    break;
                case 13:
                    borderCharacter13.Background = Brushes.Yellow;
                    borderCharacter13.BorderThickness = new Thickness(2);
                    break;
                case 14:
                    borderCharacter14.Background = Brushes.Yellow;
                    borderCharacter14.BorderThickness = new Thickness(2);
                    break;
                case 15:
                    borderCharacter15.Background = Brushes.Yellow;
                    borderCharacter15.BorderThickness = new Thickness(2);
                    break;
            }
        }

        private void cbDMMode_Click(object sender, RoutedEventArgs e)
        {
            myCharacters.bDMMode = (bool) cbDMMode.IsChecked;
            showActive();
        }

        private void showActive()
        {
            if (cbDMMode.IsChecked == true)
            {
                txtDash1.Visibility = Visibility.Hidden;
                txtDash2.Visibility = Visibility.Hidden;
                txtDash3.Visibility = Visibility.Hidden;
                txtDash4.Visibility = Visibility.Hidden;
                txtDash5.Visibility = Visibility.Hidden;
                txtDash6.Visibility = Visibility.Hidden;
                txtDash7.Visibility = Visibility.Hidden;
                txtDash8.Visibility = Visibility.Hidden;
                txtDash9.Visibility = Visibility.Hidden;
                txtDash10.Visibility = Visibility.Hidden;
                txtDash11.Visibility = Visibility.Hidden;
                txtDash12.Visibility = Visibility.Hidden;
                txtDash13.Visibility = Visibility.Hidden;
                txtDash14.Visibility = Visibility.Hidden;
                txtDash15.Visibility = Visibility.Hidden; 
                txtACHigh1.Visibility = Visibility.Hidden;
                txtACHigh2.Visibility = Visibility.Hidden;
                txtACHigh3.Visibility = Visibility.Hidden;
                txtACHigh4.Visibility = Visibility.Hidden;
                txtACHigh5.Visibility = Visibility.Hidden;
                txtACHigh6.Visibility = Visibility.Hidden;
                txtACHigh7.Visibility = Visibility.Hidden;
                txtACHigh8.Visibility = Visibility.Hidden;
                txtACHigh9.Visibility = Visibility.Hidden;
                txtACHigh10.Visibility = Visibility.Hidden;
                txtACHigh11.Visibility = Visibility.Hidden;
                txtACHigh12.Visibility = Visibility.Hidden;
                txtACHigh13.Visibility = Visibility.Hidden;
                txtACHigh14.Visibility = Visibility.Hidden;
                txtACHigh15.Visibility = Visibility.Hidden; 
                btnAddDamage1.Visibility = Visibility.Hidden;
                btnAddDamage2.Visibility = Visibility.Hidden;
                btnAddDamage3.Visibility = Visibility.Hidden;
                btnAddDamage4.Visibility = Visibility.Hidden;
                btnAddDamage5.Visibility = Visibility.Hidden;
                btnAddDamage6.Visibility = Visibility.Hidden;
                btnAddDamage7.Visibility = Visibility.Hidden;
                btnAddDamage8.Visibility = Visibility.Hidden;
                btnAddDamage9.Visibility = Visibility.Hidden;
                btnAddDamage10.Visibility = Visibility.Hidden;
                btnAddDamage11.Visibility = Visibility.Hidden;
                btnAddDamage12.Visibility = Visibility.Hidden;
                btnAddDamage13.Visibility = Visibility.Hidden;
                btnAddDamage14.Visibility = Visibility.Hidden;
                btnAddDamage15.Visibility = Visibility.Hidden; 
                btnSubtractDamage1.Visibility = Visibility.Visible;
                btnSubtractDamage2.Visibility = Visibility.Visible;
                btnSubtractDamage3.Visibility = Visibility.Visible;
                btnSubtractDamage4.Visibility = Visibility.Visible;
                btnSubtractDamage5.Visibility = Visibility.Visible;
                btnSubtractDamage6.Visibility = Visibility.Visible;
                btnSubtractDamage7.Visibility = Visibility.Visible;
                btnSubtractDamage8.Visibility = Visibility.Visible;
                btnSubtractDamage9.Visibility = Visibility.Visible;
                btnSubtractDamage10.Visibility = Visibility.Visible;
                btnSubtractDamage11.Visibility = Visibility.Visible;
                btnSubtractDamage12.Visibility = Visibility.Visible;
                btnSubtractDamage13.Visibility = Visibility.Visible;
                btnSubtractDamage14.Visibility = Visibility.Visible;
                btnSubtractDamage15.Visibility = Visibility.Visible; 
                spTracker1.Visibility = Visibility.Visible;
                spTracker2.Visibility = Visibility.Visible;
                spTracker3.Visibility = Visibility.Visible;
                spTracker4.Visibility = Visibility.Visible;
                spTracker5.Visibility = Visibility.Visible;
                spTracker6.Visibility = Visibility.Visible;
                spTracker7.Visibility = Visibility.Visible;
                spTracker8.Visibility = Visibility.Visible;
                spTracker9.Visibility = Visibility.Visible;
                spTracker10.Visibility = Visibility.Visible;
                spTracker11.Visibility = Visibility.Visible;
                spTracker12.Visibility = Visibility.Visible;
                spTracker13.Visibility = Visibility.Visible;
                spTracker14.Visibility = Visibility.Visible;
                spTracker15.Visibility = Visibility.Visible; 
                lblHP1.Text = "HP:";
                lblHP2.Text = "HP:";
                lblHP3.Text = "HP:";
                lblHP4.Text = "HP:";
                lblHP5.Text = "HP:";
                lblHP6.Text = "HP:";
                lblHP7.Text = "HP:";
                lblHP8.Text = "HP:";
                lblHP9.Text = "HP:";
                lblHP10.Text = "HP:";
                lblHP11.Text = "HP:";
                lblHP12.Text = "HP:";
                lblHP13.Text = "HP:";
                lblHP14.Text = "HP:";
                lblHP15.Text = "HP:";
            }
            else
            {
                txtDash1.Visibility = Visibility.Visible;
                txtDash2.Visibility = Visibility.Visible;
                txtDash3.Visibility = Visibility.Visible;
                txtDash4.Visibility = Visibility.Visible;
                txtDash5.Visibility = Visibility.Visible;
                txtDash6.Visibility = Visibility.Visible;
                txtDash7.Visibility = Visibility.Visible;
                txtDash8.Visibility = Visibility.Visible;
                txtDash9.Visibility = Visibility.Visible;
                txtDash10.Visibility = Visibility.Visible;
                txtDash11.Visibility = Visibility.Visible;
                txtDash12.Visibility = Visibility.Visible;
                txtDash13.Visibility = Visibility.Visible;
                txtDash14.Visibility = Visibility.Visible;
                txtDash15.Visibility = Visibility.Visible; 
                txtACHigh1.Visibility = Visibility.Visible;
                txtACHigh2.Visibility = Visibility.Visible;
                txtACHigh3.Visibility = Visibility.Visible;
                txtACHigh4.Visibility = Visibility.Visible;
                txtACHigh5.Visibility = Visibility.Visible;
                txtACHigh6.Visibility = Visibility.Visible;
                txtACHigh7.Visibility = Visibility.Visible;
                txtACHigh8.Visibility = Visibility.Visible;
                txtACHigh9.Visibility = Visibility.Visible;
                txtACHigh10.Visibility = Visibility.Visible;
                txtACHigh11.Visibility = Visibility.Visible;
                txtACHigh12.Visibility = Visibility.Visible;
                txtACHigh13.Visibility = Visibility.Visible;
                txtACHigh14.Visibility = Visibility.Visible;
                txtACHigh15.Visibility = Visibility.Visible;
                btnAddDamage1.Visibility = Visibility.Visible;
                btnAddDamage2.Visibility = Visibility.Visible;
                btnAddDamage3.Visibility = Visibility.Visible;
                btnAddDamage4.Visibility = Visibility.Visible;
                btnAddDamage5.Visibility = Visibility.Visible;
                btnAddDamage6.Visibility = Visibility.Visible;
                btnAddDamage7.Visibility = Visibility.Visible;
                btnAddDamage8.Visibility = Visibility.Visible;
                btnAddDamage9.Visibility = Visibility.Visible;
                btnAddDamage10.Visibility = Visibility.Visible;
                btnAddDamage11.Visibility = Visibility.Visible;
                btnAddDamage12.Visibility = Visibility.Visible;
                btnAddDamage13.Visibility = Visibility.Visible;
                btnAddDamage14.Visibility = Visibility.Visible;
                btnAddDamage15.Visibility = Visibility.Visible;
                btnSubtractDamage1.Visibility = Visibility.Hidden;
                btnSubtractDamage2.Visibility = Visibility.Hidden;
                btnSubtractDamage3.Visibility = Visibility.Hidden;
                btnSubtractDamage4.Visibility = Visibility.Hidden;
                btnSubtractDamage5.Visibility = Visibility.Hidden;
                btnSubtractDamage6.Visibility = Visibility.Hidden;
                btnSubtractDamage7.Visibility = Visibility.Hidden;
                btnSubtractDamage8.Visibility = Visibility.Hidden;
                btnSubtractDamage9.Visibility = Visibility.Hidden;
                btnSubtractDamage10.Visibility = Visibility.Hidden;
                btnSubtractDamage11.Visibility = Visibility.Hidden;
                btnSubtractDamage12.Visibility = Visibility.Hidden;
                btnSubtractDamage13.Visibility = Visibility.Hidden;
                btnSubtractDamage14.Visibility = Visibility.Hidden;
                btnSubtractDamage15.Visibility = Visibility.Hidden; if (Lock1.IsChecked == true)
                    spTracker1.Visibility = Visibility.Hidden;
                else
                    spTracker1.Visibility = Visibility.Visible;
                if (Lock2.IsChecked == true)
                    spTracker2.Visibility = Visibility.Hidden;
                else
                    spTracker2.Visibility = Visibility.Visible;
                if (Lock3.IsChecked == true)
                    spTracker3.Visibility = Visibility.Hidden;
                else
                    spTracker3.Visibility = Visibility.Visible;
                if (Lock4.IsChecked == true)
                    spTracker4.Visibility = Visibility.Hidden;
                else
                    spTracker4.Visibility = Visibility.Visible;
                if (Lock5.IsChecked == true)
                    spTracker5.Visibility = Visibility.Hidden;
                else
                    spTracker5.Visibility = Visibility.Visible;
                if (Lock6.IsChecked == true)
                    spTracker6.Visibility = Visibility.Hidden;
                else
                    spTracker6.Visibility = Visibility.Visible;
                if (Lock7.IsChecked == true)
                    spTracker7.Visibility = Visibility.Hidden;
                else
                    spTracker7.Visibility = Visibility.Visible;
                if (Lock8.IsChecked == true)
                    spTracker8.Visibility = Visibility.Hidden;
                else
                    spTracker8.Visibility = Visibility.Visible;
                if (Lock9.IsChecked == true)
                    spTracker9.Visibility = Visibility.Hidden;
                else
                    spTracker9.Visibility = Visibility.Visible;
                if (Lock10.IsChecked == true)
                    spTracker10.Visibility = Visibility.Hidden;
                else
                    spTracker10.Visibility = Visibility.Visible;
                if (Lock11.IsChecked == true)
                    spTracker11.Visibility = Visibility.Hidden;
                else
                    spTracker11.Visibility = Visibility.Visible;
                if (Lock12.IsChecked == true)
                    spTracker12.Visibility = Visibility.Hidden;
                else
                    spTracker12.Visibility = Visibility.Visible;
                if (Lock13.IsChecked == true)
                    spTracker13.Visibility = Visibility.Hidden;
                else
                    spTracker13.Visibility = Visibility.Visible;
                if (Lock14.IsChecked == true)
                    spTracker14.Visibility = Visibility.Hidden;
                else
                    spTracker14.Visibility = Visibility.Visible;
                if (Lock15.IsChecked == true)
                    spTracker15.Visibility = Visibility.Hidden;
                else
                    spTracker15.Visibility = Visibility.Visible; 
                lblHP1.Text = "Dmg:";
                lblHP2.Text = "Dmg:";
                lblHP3.Text = "Dmg:";
                lblHP4.Text = "Dmg:";
                lblHP5.Text = "Dmg:";
                lblHP6.Text = "Dmg:";
                lblHP7.Text = "Dmg:";
                lblHP8.Text = "Dmg:";
                lblHP9.Text = "Dmg:";
                lblHP10.Text = "Dmg:";
                lblHP11.Text = "Dmg:";
                lblHP12.Text = "Dmg:";
                lblHP13.Text = "Dmg:";
                lblHP14.Text = "Dmg:";
                lblHP15.Text = "Dmg:";
            }
            if (Condition1a.Text == "Normal" || Condition1a.Text == "Dead")
                Condition1b.Visibility = Visibility.Hidden;
            else
                Condition1b.Visibility = Visibility.Visible;
            if (Condition2a.Text == "Normal" || Condition2a.Text == "Dead")
                Condition2b.Visibility = Visibility.Hidden;
            else
                Condition2b.Visibility = Visibility.Visible;
            if (Condition3a.Text == "Normal" || Condition3a.Text == "Dead")
                Condition3b.Visibility = Visibility.Hidden;
            else
                Condition3b.Visibility = Visibility.Visible;
            if (Condition4a.Text == "Normal" || Condition4a.Text == "Dead")
                Condition4b.Visibility = Visibility.Hidden;
            else
                Condition4b.Visibility = Visibility.Visible;
            if (Condition5a.Text == "Normal" || Condition5a.Text == "Dead")
                Condition5b.Visibility = Visibility.Hidden;
            else
                Condition5b.Visibility = Visibility.Visible;
            if (Condition6a.Text == "Normal" || Condition6a.Text == "Dead")
                Condition6b.Visibility = Visibility.Hidden;
            else
                Condition6b.Visibility = Visibility.Visible;
            if (Condition7a.Text == "Normal" || Condition7a.Text == "Dead")
                Condition7b.Visibility = Visibility.Hidden;
            else
                Condition7b.Visibility = Visibility.Visible;
            if (Condition8a.Text == "Normal" || Condition8a.Text == "Dead")
                Condition8b.Visibility = Visibility.Hidden;
            else
                Condition8b.Visibility = Visibility.Visible;
            if (Condition9a.Text == "Normal" || Condition9a.Text == "Dead")
                Condition9b.Visibility = Visibility.Hidden;
            else
                Condition9b.Visibility = Visibility.Visible;
            if (Condition10a.Text == "Normal" || Condition10a.Text == "Dead")
                Condition10b.Visibility = Visibility.Hidden;
            else
                Condition10b.Visibility = Visibility.Visible;
            if (Condition11a.Text == "Normal" || Condition11a.Text == "Dead")
                Condition11b.Visibility = Visibility.Hidden;
            else
                Condition11b.Visibility = Visibility.Visible;
            if (Condition12a.Text == "Normal" || Condition12a.Text == "Dead")
                Condition12b.Visibility = Visibility.Hidden;
            else
                Condition12b.Visibility = Visibility.Visible;
            if (Condition13a.Text == "Normal" || Condition13a.Text == "Dead")
                Condition13b.Visibility = Visibility.Hidden;
            else
                Condition13b.Visibility = Visibility.Visible;
            if (Condition14a.Text == "Normal" || Condition14a.Text == "Dead")
                Condition14b.Visibility = Visibility.Hidden;
            else
                Condition14b.Visibility = Visibility.Visible;
            if (Condition15a.Text == "Normal" || Condition15a.Text == "Dead")
                Condition15b.Visibility = Visibility.Hidden;
            else
                Condition15b.Visibility = Visibility.Visible;
        }
        #endregion

        #region "Screen Functions"
        public void updateScreenValues()
        {
            cbDMMode.IsChecked = myCharacters.bDMMode;

            if (myCharacters.Attribs[0].Visible == true)
                borderCharacter1.Visibility = Visibility.Visible;
            else
                borderCharacter1.Visibility = Visibility.Hidden;
            txtInitiative1.Text = myCharacters.Attribs[0].Initiative;
            txtName1.Text = myCharacters.Attribs[0].Name;
            Lock1.IsChecked = myCharacters.Attribs[0].Lock;
            txtInit1.Text = myCharacters.Attribs[0].InitRoll;
            txtACLow1.Text = myCharacters.Attribs[0].ACLow;
            txtACHigh1.Text = myCharacters.Attribs[0].ACHigh;
            txtTotalDamage1.Text = myCharacters.Attribs[0].HP;
            Condition1a.Text = myCharacters.Attribs[0].ConditionA;
            Condition1b.Text = myCharacters.Attribs[0].ConditionB;

            if (myCharacters.Attribs[1].Visible == true)
                borderCharacter2.Visibility = Visibility.Visible;
            else
                borderCharacter2.Visibility = Visibility.Hidden;
            txtInitiative2.Text = myCharacters.Attribs[1].Initiative;
            txtName2.Text = myCharacters.Attribs[1].Name;
            Lock2.IsChecked = myCharacters.Attribs[1].Lock;
            txtInit2.Text = myCharacters.Attribs[1].InitRoll;
            txtACLow2.Text = myCharacters.Attribs[1].ACLow;
            txtACHigh2.Text = myCharacters.Attribs[1].ACHigh;
            txtTotalDamage2.Text = myCharacters.Attribs[1].HP;
            Condition2a.Text = myCharacters.Attribs[1].ConditionA;
            Condition2b.Text = myCharacters.Attribs[1].ConditionB;

            if (myCharacters.Attribs[2].Visible == true)
                borderCharacter3.Visibility = Visibility.Visible;
            else
                borderCharacter3.Visibility = Visibility.Hidden;
            txtInitiative3.Text = myCharacters.Attribs[2].Initiative;
            txtName3.Text = myCharacters.Attribs[2].Name;
            Lock3.IsChecked = myCharacters.Attribs[2].Lock;
            txtInit3.Text = myCharacters.Attribs[2].InitRoll;
            txtACLow3.Text = myCharacters.Attribs[2].ACLow;
            txtACHigh3.Text = myCharacters.Attribs[2].ACHigh;
            txtTotalDamage3.Text = myCharacters.Attribs[2].HP;
            Condition3a.Text = myCharacters.Attribs[2].ConditionA;
            Condition3b.Text = myCharacters.Attribs[2].ConditionB;

            if (myCharacters.Attribs[3].Visible == true)
                borderCharacter4.Visibility = Visibility.Visible;
            else
                borderCharacter4.Visibility = Visibility.Hidden;
            txtInitiative4.Text = myCharacters.Attribs[3].Initiative;
            txtName4.Text = myCharacters.Attribs[3].Name;
            Lock4.IsChecked = myCharacters.Attribs[3].Lock;
            txtInit4.Text = myCharacters.Attribs[3].InitRoll;
            txtACLow4.Text = myCharacters.Attribs[3].ACLow;
            txtACHigh4.Text = myCharacters.Attribs[3].ACHigh;
            txtTotalDamage4.Text = myCharacters.Attribs[3].HP;
            Condition4a.Text = myCharacters.Attribs[3].ConditionA;
            Condition4b.Text = myCharacters.Attribs[3].ConditionB;

            if (myCharacters.Attribs[4].Visible == true)
                borderCharacter5.Visibility = Visibility.Visible;
            else
                borderCharacter5.Visibility = Visibility.Hidden;
            txtInitiative5.Text = myCharacters.Attribs[4].Initiative;
            txtName5.Text = myCharacters.Attribs[4].Name;
            Lock5.IsChecked = myCharacters.Attribs[4].Lock;
            txtInit5.Text = myCharacters.Attribs[4].InitRoll;
            txtACLow5.Text = myCharacters.Attribs[4].ACLow;
            txtACHigh5.Text = myCharacters.Attribs[4].ACHigh;
            txtTotalDamage5.Text = myCharacters.Attribs[4].HP;
            Condition5a.Text = myCharacters.Attribs[4].ConditionA;
            Condition5b.Text = myCharacters.Attribs[4].ConditionB;

            if (myCharacters.Attribs[5].Visible == true)
                borderCharacter6.Visibility = Visibility.Visible;
            else
                borderCharacter6.Visibility = Visibility.Hidden;
            txtInitiative6.Text = myCharacters.Attribs[5].Initiative;
            txtName6.Text = myCharacters.Attribs[5].Name;
            Lock6.IsChecked = myCharacters.Attribs[5].Lock;
            txtInit6.Text = myCharacters.Attribs[5].InitRoll;
            txtACLow6.Text = myCharacters.Attribs[5].ACLow;
            txtACHigh6.Text = myCharacters.Attribs[5].ACHigh;
            txtTotalDamage6.Text = myCharacters.Attribs[5].HP;
            Condition6a.Text = myCharacters.Attribs[5].ConditionA;
            Condition6b.Text = myCharacters.Attribs[5].ConditionB;

            if (myCharacters.Attribs[6].Visible == true)
                borderCharacter7.Visibility = Visibility.Visible;
            else
                borderCharacter7.Visibility = Visibility.Hidden;
            txtInitiative7.Text = myCharacters.Attribs[6].Initiative;
            txtName7.Text = myCharacters.Attribs[6].Name;
            Lock7.IsChecked = myCharacters.Attribs[6].Lock;
            txtInit7.Text = myCharacters.Attribs[6].InitRoll;
            txtACLow7.Text = myCharacters.Attribs[6].ACLow;
            txtACHigh7.Text = myCharacters.Attribs[6].ACHigh;
            txtTotalDamage7.Text = myCharacters.Attribs[6].HP;
            Condition7a.Text = myCharacters.Attribs[6].ConditionA;
            Condition7b.Text = myCharacters.Attribs[6].ConditionB;

            if (myCharacters.Attribs[7].Visible == true)
                borderCharacter8.Visibility = Visibility.Visible;
            else
                borderCharacter8.Visibility = Visibility.Hidden;
            txtInitiative8.Text = myCharacters.Attribs[7].Initiative;
            txtName8.Text = myCharacters.Attribs[7].Name;
            Lock8.IsChecked = myCharacters.Attribs[7].Lock;
            txtInit8.Text = myCharacters.Attribs[7].InitRoll;
            txtACLow8.Text = myCharacters.Attribs[7].ACLow;
            txtACHigh8.Text = myCharacters.Attribs[7].ACHigh;
            txtTotalDamage8.Text = myCharacters.Attribs[7].HP;
            Condition8a.Text = myCharacters.Attribs[7].ConditionA;
            Condition8b.Text = myCharacters.Attribs[7].ConditionB;

            if (myCharacters.Attribs[8].Visible == true)
                borderCharacter9.Visibility = Visibility.Visible;
            else
                borderCharacter9.Visibility = Visibility.Hidden;
            txtInitiative9.Text = myCharacters.Attribs[8].Initiative;
            txtName9.Text = myCharacters.Attribs[8].Name;
            Lock9.IsChecked = myCharacters.Attribs[8].Lock;
            txtInit9.Text = myCharacters.Attribs[8].InitRoll;
            txtACLow9.Text = myCharacters.Attribs[8].ACLow;
            txtACHigh9.Text = myCharacters.Attribs[8].ACHigh;
            txtTotalDamage9.Text = myCharacters.Attribs[8].HP;
            Condition9a.Text = myCharacters.Attribs[8].ConditionA;
            Condition9b.Text = myCharacters.Attribs[8].ConditionB;

            if (myCharacters.Attribs[9].Visible == true)
                borderCharacter10.Visibility = Visibility.Visible;
            else
                borderCharacter10.Visibility = Visibility.Hidden;
            txtInitiative10.Text = myCharacters.Attribs[9].Initiative;
            txtName10.Text = myCharacters.Attribs[9].Name;
            Lock10.IsChecked = myCharacters.Attribs[9].Lock;
            txtInit10.Text = myCharacters.Attribs[9].InitRoll;
            txtACLow10.Text = myCharacters.Attribs[9].ACLow;
            txtACHigh10.Text = myCharacters.Attribs[9].ACHigh;
            txtTotalDamage10.Text = myCharacters.Attribs[9].HP;
            Condition10a.Text = myCharacters.Attribs[9].ConditionA;
            Condition10b.Text = myCharacters.Attribs[9].ConditionB;

            if (myCharacters.Attribs[10].Visible == true)
                borderCharacter11.Visibility = Visibility.Visible;
            else
                borderCharacter11.Visibility = Visibility.Hidden;
            txtInitiative11.Text = myCharacters.Attribs[10].Initiative;
            txtName11.Text = myCharacters.Attribs[10].Name;
            Lock11.IsChecked = myCharacters.Attribs[10].Lock;
            txtInit11.Text = myCharacters.Attribs[10].InitRoll;
            txtACLow11.Text = myCharacters.Attribs[10].ACLow;
            txtACHigh11.Text = myCharacters.Attribs[10].ACHigh;
            txtTotalDamage11.Text = myCharacters.Attribs[10].HP;
            Condition11a.Text = myCharacters.Attribs[10].ConditionA;
            Condition11b.Text = myCharacters.Attribs[10].ConditionB;

            if (myCharacters.Attribs[11].Visible == true)
                borderCharacter12.Visibility = Visibility.Visible;
            else
                borderCharacter12.Visibility = Visibility.Hidden;
            txtInitiative12.Text = myCharacters.Attribs[11].Initiative;
            txtName12.Text = myCharacters.Attribs[11].Name;
            Lock12.IsChecked = myCharacters.Attribs[11].Lock;
            txtInit12.Text = myCharacters.Attribs[11].InitRoll;
            txtACLow12.Text = myCharacters.Attribs[11].ACLow;
            txtACHigh12.Text = myCharacters.Attribs[11].ACHigh;
            txtTotalDamage12.Text = myCharacters.Attribs[11].HP;
            Condition12a.Text = myCharacters.Attribs[11].ConditionA;
            Condition12b.Text = myCharacters.Attribs[11].ConditionB;

            if (myCharacters.Attribs[12].Visible == true)
                borderCharacter13.Visibility = Visibility.Visible;
            else
                borderCharacter13.Visibility = Visibility.Hidden;
            txtInitiative13.Text = myCharacters.Attribs[12].Initiative;
            txtName13.Text = myCharacters.Attribs[12].Name;
            Lock13.IsChecked = myCharacters.Attribs[12].Lock;
            txtInit13.Text = myCharacters.Attribs[12].InitRoll;
            txtACLow13.Text = myCharacters.Attribs[12].ACLow;
            txtACHigh13.Text = myCharacters.Attribs[12].ACHigh;
            txtTotalDamage13.Text = myCharacters.Attribs[12].HP;
            Condition13a.Text = myCharacters.Attribs[12].ConditionA;
            Condition13b.Text = myCharacters.Attribs[12].ConditionB;

            if (myCharacters.Attribs[13].Visible == true)
                borderCharacter14.Visibility = Visibility.Visible;
            else
                borderCharacter14.Visibility = Visibility.Hidden;
            txtInitiative14.Text = myCharacters.Attribs[13].Initiative;
            txtName14.Text = myCharacters.Attribs[13].Name;
            Lock14.IsChecked = myCharacters.Attribs[13].Lock;
            txtInit14.Text = myCharacters.Attribs[13].InitRoll;
            txtACLow14.Text = myCharacters.Attribs[13].ACLow;
            txtACHigh14.Text = myCharacters.Attribs[13].ACHigh;
            txtTotalDamage14.Text = myCharacters.Attribs[13].HP;
            Condition14a.Text = myCharacters.Attribs[13].ConditionA;
            Condition14b.Text = myCharacters.Attribs[13].ConditionB;

            if (myCharacters.Attribs[14].Visible == true)
                borderCharacter15.Visibility = Visibility.Visible;
            else
                borderCharacter15.Visibility = Visibility.Hidden;
            txtInitiative15.Text = myCharacters.Attribs[14].Initiative;
            txtName15.Text = myCharacters.Attribs[14].Name;
            Lock15.IsChecked = myCharacters.Attribs[14].Lock;
            txtInit15.Text = myCharacters.Attribs[14].InitRoll;
            txtACLow15.Text = myCharacters.Attribs[14].ACLow;
            txtACHigh15.Text = myCharacters.Attribs[14].ACHigh;
            txtTotalDamage15.Text = myCharacters.Attribs[14].HP;
            Condition15a.Text = myCharacters.Attribs[14].ConditionA;
            Condition15b.Text = myCharacters.Attribs[14].ConditionB;
        }

        private void updateData()
        {
            updateData1();
            updateData2();
            updateData3();
            updateData4();
            updateData5();
            updateData6();
            updateData7();
            updateData8();
            updateData9();
            updateData10();
            updateData11();
            updateData12();
            updateData13();
            updateData14();
            updateData15();
            //updateData16();
            //updateData17();
            //updateData18();
            //updateData19();
            //updateData20();
        }



        #endregion


    }
}
