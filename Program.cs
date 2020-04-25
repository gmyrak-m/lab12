using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


class myMainMenu : MainMenu
{
    MenuItem itemFile = new MenuItem("Файл");
    MenuItem itemExit = new MenuItem("Выход");
    MenuItem itemAbout = new MenuItem("О программе");

    MenuItem itemActions = new MenuItem("Действия");
    MenuItem itemA1 = new MenuItem("Площадь");
    MenuItem itemA2 = new MenuItem("Краска");
    MenuItem itemA3 = new MenuItem("Цена");

    public myMainMenu()
    {
        itemFile.MenuItems.Add(itemAbout);
        itemFile.MenuItems.Add(itemExit);

        itemActions.MenuItems.Add(itemA1);
        itemActions.MenuItems.Add(itemA2);
        itemActions.MenuItems.Add(itemA3);

        this.MenuItems.Add(itemFile);
        this.MenuItems.Add(itemActions);


        itemExit.Click += (obj, e) => Application.Exit();
        itemAbout.Click += (obj, e) => MessageBox.Show("Программа разработана в учебных целях студенткой 2-го курса 186 специальности Гмырак Марией. 2020",
            "О программе",
            MessageBoxButtons.OK);

        itemA1.Click += ItemA1_Click;
        itemA2.Click += ItemA2_Click;
        itemA3.Click += ItemA3_Click;

    }

    private void ItemA3_Click(object sender, EventArgs e)
    {
        (new formPrice(0)).ShowDialog();
    }

    private void ItemA2_Click(object sender, EventArgs e)
    {
        (new formColor(0)).ShowDialog();
    }

    private void ItemA1_Click(object sender, EventArgs e)
    {
        formAreaCalculate fac = new formAreaCalculate();
        fac.ShowDialog();
    }
}


class formAreaCalculate : Form
{
    NumericUpDown xControl = new NumericUpDown();
    NumericUpDown yControl = new NumericUpDown();
    Label xLabel = new Label();
    Label yLabel = new Label();
    Label sLabel = new Label();
    Button okButton = new Button();
    Button nextButton = new Button();

    public formAreaCalculate()
    {
        Text = "Площадь";
        xLabel.Text = "Ширина";
        yLabel.Text = "Высота";
       
        xLabel.Location = new Point(10, 10);
        yLabel.Location = new Point(10, 50);
        sLabel.Location = new Point(10, 100);
        okButton.Location = new Point(10, 130);
        nextButton.Location = new Point(10, 160);
        okButton.Text = "Расчитать";
        nextButton.Text = "Продолжить...";

        xControl.Location = new Point(60, 10);
        yControl.Location = new Point(60, 50);
        this.Controls.Add(xControl);
        this.Controls.Add(yControl);
        this.Controls.Add(xLabel);
        this.Controls.Add(yLabel);
        this.Controls.Add(okButton);
        this.Controls.Add(sLabel);
        this.Controls.Add(nextButton);

        okButton.Click += OkButton_Click;
        nextButton.Click += NextButton_Click;

    }

    private void NextButton_Click(object sender, EventArgs e)
    {
        this.Hide();
        (new formColor(xControl.Value * yControl.Value)).ShowDialog();

    }

    private void OkButton_Click(object sender, EventArgs e)
    {
        sLabel.Text = "Площадь: " + (xControl.Value * yControl.Value).ToString();
    }
}


class formColor : Form
{
    NumericUpDown xControl = new NumericUpDown();
    Label xLabel = new Label();
    Label colorLabel = new Label();
    Button okButton = new Button();
    Button nextButton = new Button();

    public formColor(decimal area)
    {
        Text = "Количество краски";
        xLabel.Text = "Площадь";


        xLabel.Location = new Point(10, 10);
        colorLabel.Location = new Point(10, 100);
        colorLabel.Size = new Size(200, 20);
        okButton.Location = new Point(10, 130);
        nextButton.Location = new Point(10, 160);
        okButton.Text = "Расчитать";
        nextButton.Text = "Продолжить...";
        xControl.Maximum = 10000;

        xControl.Location = new Point(70, 10);
        xControl.Value = area;
        this.Controls.Add(xControl);
        this.Controls.Add(xLabel);
        this.Controls.Add(okButton);
        this.Controls.Add(colorLabel);
        this.Controls.Add(nextButton);

        okButton.Click += OkButton_Click;
        nextButton.Click += NextButton_Click;


    }

    private void NextButton_Click(object sender, EventArgs e)
    {
        this.Hide();
        (new formPrice(xControl.Value * 3)).ShowDialog();
    }

    private void OkButton_Click(object sender, EventArgs e)
    {
        colorLabel.Text = "Количество краски: " + xControl.Value * 3 + " г.";
    }
}


class formPrice : Form
{
    NumericUpDown xControl = new NumericUpDown();
    Label xLabel = new Label();
    Label colorLabel = new Label();
    Button okButton = new Button();

    public formPrice(decimal color)
    {
        Text = "Цена краски";
        xLabel.Text = "Количество краски";
        xControl.Maximum = 10000;

        xControl.Value = color;


        xLabel.Location = new Point(10, 10);
        colorLabel.Location = new Point(10, 100);
        colorLabel.Size = new Size(200, 20);
        okButton.Location = new Point(10, 130);
        okButton.Text = "Расчитать";
        

        xControl.Location = new Point(80, 10);
        this.Controls.Add(xControl);
        this.Controls.Add(xLabel);
        this.Controls.Add(okButton);
        this.Controls.Add(colorLabel);

        okButton.Click += OkButton_Click;

    }

    private void OkButton_Click(object sender, EventArgs e)
    {
        colorLabel.Text = "Цена: " + xControl.Value * 5 + " грн.";
    }
}



class MyForm : Form
{
    Button myButton = new Button();
    Label formText = new Label();   

    Button exit = new Button();

    int pressCounter = 0;
    Random rand = new Random();

    public MyForm()
    {
        Size = new Size(800, 600);

        Text = "Ремонт. Гмырак Мария";
        myButton.Text = "Нажми меня";
        myButton.Location = new Point(100, 100);
        myButton.Size = new Size(100, 40);

        exit.Text = "Выход";
        exit.Location = new Point(100, 200);
      
        
        formText.Text = "Кнопка еще не нажата";
        formText.Size = new Size(150, 40);

        //Controls.Add(myButton);
        Controls.Add(formText);
        //Controls.Add(exit);

        myButton.Click += MyButton_Click;
        exit.Click += Exit_Click;

        Menu = new myMainMenu();

        

    }

    private void Exit_Click(object sender, EventArgs e)
    {
        DialogResult result = MessageBox.Show("Закрыть программу?", "Выход", MessageBoxButtons.YesNo);
        if (result == DialogResult.Yes)
        {
            Application.Exit();
        }

    }

    private void MyButton_Click(object sender, EventArgs e)
    {
        pressCounter++;
        formText.Text = "Нажатий: " + pressCounter;

        myButton.Location = new Point(rand.Next(100, 700), rand.Next(100, 500));

    }

    [STAThread]
    public static void Main()
    {
        MyForm mf = new MyForm();
        Application.Run(mf);
    }


}


