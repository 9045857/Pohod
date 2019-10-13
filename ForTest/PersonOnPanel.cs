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
    public class PersonOnPanel
    {
        public Person Person { get; private set; }

        public int ID { get; set; }

        public CheckBox CheckBoxIsDebtor { get; set; } = new CheckBox();
        public TextBox TextBoxFactor { get; set; } = new TextBox();
        public TextBox TextBoxDebt { get; set; } = new TextBox();
        public TextBox TextBoxPayment { get; set; } = new TextBox();

        private int _xBetweenControls = 5;
        private int _xTextEditWidth = 30;
        private int _positionX = 2;

        private int _y;
        private readonly int _height = 20;

        private int _CheckBoxIsDebtorX;
        private int _TextBoxFactorX;
        private int _TextBoxDebtX;
        private int _TextBoxPaymentX;

        private Panel panel;

        //public Debt(Panel panel, Person person)
        //{
        //    this.panel = panel;
        //    this.Person = person;
        //}

        public PersonOnPanel(Panel panel,int id)
        {
            this.panel = panel;
            // this.Person = person;

            _CheckBoxIsDebtorX = _positionX;
            _TextBoxFactorX = _positionX + CheckBoxIsDebtor.Width;
            _TextBoxDebtX = _positionX + CheckBoxIsDebtor.Width + _xBetweenControls + _xTextEditWidth;
            _TextBoxPaymentX = _positionX + CheckBoxIsDebtor.Width + 2 * _xBetweenControls + 2 * _xTextEditWidth;

            ID = id;

            CreateUnit();
        }



        //public void DrawOnPanel(Person person, int id)
        //{
        //    Person = person;
        //    ID = id;
        //    FillAndShowUnit();
        //}




        //public PersonOnPanel(Panel panel, Person person, int debtNumber)
        //{
        //    this.panel = panel;
        //    this.Person = person;

        //    CreateUnit(debtNumber);
        //}


        //public bool TrySetUnitInfoToProduct(Product product)
        //{
        //    if (i double)

        //}

        public void Clear()
        {
            Person = null;
            Visible = false;
        }

        private void CreateUnit()
        {
            Visible = false;

            _y = _height * ID;

            CheckBoxIsDebtor.Parent = panel;
            CheckBoxIsDebtor.Location = new Point(_CheckBoxIsDebtorX, _y);

            TextBoxFactor.Parent = panel;
            TextBoxFactor.Location = new Point(_TextBoxFactorX, _y);
            TextBoxFactor.Width = _xTextEditWidth;

            TextBoxDebt.Parent = panel;
            TextBoxDebt.Location = new Point(_TextBoxDebtX, _y);
            TextBoxDebt.Width = _xTextEditWidth;

            TextBoxPayment.Parent = panel;
            TextBoxPayment.Location = new Point(_TextBoxPaymentX, _y);
            TextBoxPayment.Width = _xTextEditWidth;          
        }

        public bool Visible
        {
            get
            {
                return CheckBoxIsDebtor.Visible;
            }
            set
            {
                CheckBoxIsDebtor.Visible = value;
                TextBoxFactor.Visible = value;
                TextBoxDebt.Visible = value;
                TextBoxPayment.Visible = value;
            }
        }

        public void FillAndShowUnit(Person person/*, int id*/)
        {
            if (person == null)
            {
                Visible = false;
                return;
            }

            Person = person;
           // ID = id;

            _y = _height * ID;

            CheckBoxIsDebtor.Text = Person.Name;
          //  CheckBoxIsDebtor.Location = new Point(_CheckBoxIsDebtorX, _y);
            CheckBoxIsDebtor.Checked = true;

            TextBoxFactor.Text = Person.DebtFactor.ToString();
        //    TextBoxFactor.Location = new Point(_TextBoxFactorX, _y);

            TextBoxDebt.Text = "";
         //   TextBoxDebt.Location = new Point(_TextBoxDebtX, _y);

            TextBoxPayment.Text = "";
            //TextBoxPayment.Location = new Point(_TextBoxPaymentX, _y);

            Visible = true;
        }

        //public void FillAndShowUnit(int id)
        //{
        //    if (Person == null)
        //    {
        //        Visible = false;
        //        return;
        //    }

        //    ID = id;

        //    _y = _height * ID;

        //    CheckBoxIsDebtor.Text = Person.Name;
        //    CheckBoxIsDebtor.Location = new Point(_CheckBoxIsDebtorX, _y);
        //    CheckBoxIsDebtor.Checked = true;

        //    TextBoxFactor.Text = Person.DebtFactor.ToString();
        //    TextBoxFactor.Location = new Point(_TextBoxFactorX, _y);

        //    TextBoxDebt.Text = "";
        //    TextBoxDebt.Location = new Point(_TextBoxDebtX, _y);

        //    TextBoxPayment.Text = "";
        //    TextBoxPayment.Location = new Point(_TextBoxPaymentX, _y);

        //    Visible = true;
        //}

        public void FillAndShowUnit()
        {
            if (Person == null)
            {
                Visible = false;
                return;
            }

            _y = _height * ID;

            CheckBoxIsDebtor.Text = Person.Name;
            CheckBoxIsDebtor.Location = new Point(_CheckBoxIsDebtorX, _y);
            CheckBoxIsDebtor.Checked = true;

            TextBoxFactor.Text = Person.DebtFactor.ToString();
            TextBoxFactor.Location = new Point(_TextBoxFactorX, _y);

            TextBoxDebt.Text = "";
            TextBoxDebt.Location = new Point(_TextBoxDebtX, _y);

            TextBoxPayment.Text = "";
            TextBoxPayment.Location = new Point(_TextBoxPaymentX, _y);

            Visible = true;
        }
    }
}
