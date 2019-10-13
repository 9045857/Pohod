using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CostSharing;

namespace ForTest
{
    public class Debt
    {
        public Person Person { get; set; }

        public List<PersonOnPanel>PeopleOnPanelMain { get; private set; }
        public PersonOnPanel PersonOnPanelMain { get; private set; }

        public PersonOnPanel PersonOnPanelCorrection { get; private set; }
        
        public int DebtID { get; private set; }

        public void SetDebtIDAndDraw(int id)
        {
                DebtID = id;
                PersonOnPanelMain = PeopleOnPanelMain[DebtID];
                PersonOnPanelMain.FillAndShowUnit(Person);            
        }
        
        public Debt(List<PersonOnPanel> peopleOnPanel,/*PersonOnPanel personOnPanel,*/ Person person, int debtNumber)
        { 
            Person = person;
            DebtID = debtNumber;

            PeopleOnPanelMain = peopleOnPanel;
            PersonOnPanelMain = peopleOnPanel[debtNumber];

            PersonOnPanelMain.FillUnit(Person);
        }

        public void SetPersoAdnShowPersonOnPanel()
        {
            PersonOnPanelMain.FillAndShowUnit(Person);
        }
        
        public CheckBox CheckBoxIsDebtor
        {
            get
            {
                return PersonOnPanelMain.CheckBoxIsDebtor;
            }
            set
            {
                PersonOnPanelMain.CheckBoxIsDebtor = value;
            }
        }

        public TextBox TextBoxDebt
        {
            get
            {
                return PersonOnPanelMain.TextBoxDebt;
            }
            set
            {
                PersonOnPanelMain.TextBoxDebt = value;
            }
        }

        public TextBox TextBoxFactor
        {
            get
            {
                return PersonOnPanelMain.TextBoxFactor;
            }
            set
            {
                PersonOnPanelMain.TextBoxFactor = value;
            }
        }

        public TextBox TextBoxPayment
        {
            get
            {
                return PersonOnPanelMain.TextBoxPayment;
            }
            set
            {
                PersonOnPanelMain.TextBoxPayment = value;
            }
        }
       
        public override string ToString()
        {
            string name = string.IsNullOrEmpty(Person.Name) ? "NonamePerson" : Person.Name;

            if (Equals(Person.PayGroupLeader, Person))
            {
                return name;
            }
            else
            {
                return "  " + name;
            }
        }
    }
}
