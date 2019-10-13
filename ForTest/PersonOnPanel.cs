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

        //  private Panel mainPanel;

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

        //public Debt(PersonOnPanel personOnPanel, Person person)
        //{
        //    PersonOnPanelMain = personOnPanel;
        //    Person = person;
        //}

        //public Debt(PersonOnPanel personOnPanel, Person person, int debtNumber)
        //{
        //    //  this.mainPanel = panel;
        //    Person = person;
        //    _debtID = debtNumber;

        //    PersonOnPanelMain = personOnPanel;
        //    PersonOnPanelMain.FillAndShowUnit(Person/*, debtNumber*/);
        //}

        public Debt(List<PersonOnPanel> peopleOnPanel,/*PersonOnPanel personOnPanel,*/ Person person, int debtNumber)
        {
            //  this.mainPanel = panel;
            
            Person = person;
            DebtID = debtNumber;

            PeopleOnPanelMain = peopleOnPanel;
            PersonOnPanelMain = peopleOnPanel[debtNumber];

            // PersonOnPanelMain = personOnPanel;
            PersonOnPanelMain.FillAndShowUnit(Person/*, debtNumber*/);
        }

        //public Debt(Panel panel, Person person)
        //{
        //    // this.mainPanel = panel;

        //    PersonOnPanelMain = new PersonOnPanel(panel);
        //    Person = person;
        //}


        //public Debt(Panel panel, Person person, int debtNumber)
        //{
        //    //  this.mainPanel = panel;
        //    Person = person;
        //    this.debtNumber = debtNumber;

        //    PersonOnPanelMain = new PersonOnPanel(panel);
        //    PersonOnPanelMain.FillAndShowUnit(Person, debtNumber);
        //}

        //public void DrawDebtOnPanel(Panel panel)
        //{
        //    PersonOnPanelCorrection = new PersonOnPanel(panel, Person, debtNumber);
        //    PersonOnPanelCorrection.CreateUnit(debtNumber);
        //}

        //public void CreateMainUnit(int debtIndex)
        //{
        //    if (PersonOnPanelMain == null)
        //    {
        //        PersonOnPanelMain = new PersonOnPanel(mainPanel, Person, debtIndex);
        //        debtNumber = debtIndex;
        //    }

        //    PersonOnPanelMain.CreateUnit(debtIndex);
        //}

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
        //public void CreateUnit(int debtNumber)
        //{
        //    _y = _height * debtNumber;

        //    CheckBox = new CheckBox
        //    {
        //        Parent = panel,
        //        Text = Person.Name,
        //        Location = new Point(_positionX, _y),
        //        Checked = true
        //    };

        //    int checkBoxLenght = CheckBox.Width;

        //    TextBoxFactor = new TextBox
        //    {
        //        Parent = panel,
        //        Text = Person.DebtFactor.ToString(),
        //        Location = new Point(_positionX + checkBoxLenght, _y),

        //        Width = _xTextEditWidth
        //    };

        //    TextBoxDebt = new TextBox
        //    {
        //        Parent = panel,
        //        Text = "",
        //        Location = new Point(_positionX + checkBoxLenght + _xBetweenControls + _xTextEditWidth, _y),

        //        Width = _xTextEditWidth
        //    };

        //    TextBoxPayment = new TextBox
        //    {
        //        Parent = panel,
        //        Text = "",
        //        Location = new Point(_positionX + checkBoxLenght + 2 * _xBetweenControls + 2 * _xTextEditWidth, _y),

        //        Width = _xTextEditWidth
        //    };
        //}

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
