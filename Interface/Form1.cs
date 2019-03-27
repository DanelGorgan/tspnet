using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Interface
{
    public partial class Form1 : Form
    {
        List<Panel> ListPanel = new List<Panel>();
        Panel[] panel = new Panel[32];
        string[] DropDownValues = { "Sasiu", "Auto", "Comenzi", "DetaliuComenzi", "Imagini", "Material", "Mecanici", "Operatii", "Client", };
        int index = -1, j = 0, k = 0;

        public Form1()
        {
            InitializeComponent();
        }


        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (index > 0)
            {
                if (index == ListPanel.Count)
                    index--;
                ListPanel[index].Visible = false;
                ListPanel[--index].Visible = true;
            }
        }

        private void dropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            carServiceLabel.Visible = false;
            int DropDownIndex = dropDown.SelectedIndex;
            foreach (Panel panel in ListPanel)
            {
                panel.Visible = false;
            }
            if (DropDownIndex != 0)
            {
                DropDownIndex *= 4;
            }
            ListPanel[DropDownIndex].Visible = true;
            index = DropDownIndex;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            carServiceLabel.Visible = false;
            if (index < ListPanel.Count - 1)
            {
                if (index >= 0)
                    ListPanel[index].Visible = false;
                ListPanel[++index].Visible = true;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] items = { "Create", "Read", "Update", "Delete" };
            string[] classes = { "ModelDesignFirst_L1.Sasiu, ModelDesignFirst_L1", "ModelDesignFirst_L1.Auto,ModelDesignFirst_L1", "ModelDesignFirst_L1.Comanda,ModelDesignFirst_L1", "ModelDesignFirst_L1.DetaliuComanda,ModelDesignFirst_L1", "ModelDesignFirst_L1.Imagine,ModelDesignFirst_L1", "ModelDesignFirst_L1.Material,ModelDesignFirst_L1", "ModelDesignFirst_L1.Mecanic,ModelDesignFirst_L1", "ModelDesignFirst_L1.Operatie,ModelDesignFirst_L1" };
            dropDown.Items.Add("Sasiu");
            dropDown.Items.Add("Auto");
            dropDown.Items.Add("Comenzi");
            dropDown.Items.Add("DetaliuComenzi");
            dropDown.Items.Add("Imagini");
            dropDown.Items.Add("Mecanici");
            dropDown.Items.Add("Material");
            dropDown.Items.Add("Operatii");
            dropDown.Items.Add("Client");
            for (int i = 0; i < 32; i++)
            {
                k = 0;
                panel[i] = new Panel
                {
                    Visible = false,
                    BackColor = Color.White,
                    Location = new Point(6, 54),
                    Size = new Size(450, 230),
                    Name = "Panel" + (i + 1),
                    AutoScroll = true
                };
                Label l1 = new Label();
                l1.Text = items[i % 4];
                l1.Size = new Size(150, 13);
                l1.Location = new Point(20, 15);
                l1.Font = new Font(l1.Font, FontStyle.Bold);
                string[] Clasa = classes[j].Split(',');
                string[] NumeClasa = Clasa[0].Split('.');
                switch (l1.Text)
                {
                    case "Create":
                        var TypeCreate = Type.GetType(classes[j]);
                        var myObject = Activator.CreateInstance(TypeCreate);
                        l1.Text = items[i % 4] + ' ' + NumeClasa[NumeClasa.Length - 1];
                        foreach (var prop in myObject.GetType().GetProperties())
                        {
                            if (prop.PropertyType.Name != prop.Name)
                            {
                                Label LC = new Label();
                                LC.Text = prop.Name;
                                LC.Location = new Point(10, 50 + k * 10);
                                LC.Size = new Size(90, 13);
                                TextBox TC = new TextBox();
                                TC.Name = "textbox" + (i + 1);
                                TC.Location = new Point(110, 50 + (k * 10));
                                TC.Size = new Size(80, 13);
                                panel[i].Controls.Add(LC);
                                panel[i].Controls.Add(TC);
                                k = k + 3;
                            }
                        }
                        Button BCreate = new Button();
                        BCreate.Text = "Save";
                        BCreate.Name = "button" + i;
                        BCreate.Location = new Point(110, 50 + (k * 10));
                        BCreate.Size = new Size(100, 30);
                        BCreate.Click += (se, ev) => {
                            MessageBox.Show("Create");
                        };
                        panel[i].Controls.Add(BCreate);
                        break;
                    case "Update":
                        var TypeUpdate = Type.GetType(classes[j]);
                        var myObjectUpdate = Activator.CreateInstance(TypeUpdate);
                        l1.Text = items[i % 4] + ' ' + NumeClasa[NumeClasa.Length - 1];
                        Label IdLabel = new Label();
                        IdLabel.Text = "Id";
                        IdLabel.Location = new Point(10, 50 + k * 10);
                        IdLabel.Size = new Size(90, 13);
                        panel[i].Controls.Add(IdLabel);
                        foreach (var prop in myObjectUpdate.GetType().GetProperties())
                        {
                            if (prop.PropertyType.Name != prop.Name)
                            {
                                Label LU = new Label();
                                LU.Text = prop.Name;
                                LU.Location = new Point(10, 50 + k * 10);
                                LU.Size = new Size(90, 13);
                                TextBox TU = new TextBox();
                                TU.Name = "textbox" + (i + 1);
                                TU.Location = new Point(110, 50 + (k * 10));
                                TU.Size = new Size(80, 13);
                                panel[i].Controls.Add(LU);
                                panel[i].Controls.Add(TU);
                                k = k + 3;
                            }
                        }
                        Button BUpdate = new Button();
                        BUpdate.Text = "Update";
                        BUpdate.Name = "button" + i;
                        BUpdate.Location = new Point(110, 50 + (k * 10));
                        BUpdate.Size = new Size(100, 30);
                        BUpdate.Click += (se, ev) => {
                            MessageBox.Show("Update");
                        };
                        panel[i].Controls.Add(BUpdate);
                        break;
                    case "Delete":
                        l1.Text = items[i % 4] + ' ' + NumeClasa[NumeClasa.Length - 1];
                        Label LD = new Label();
                        LD.Text = "Id";
                        LD.Location = new Point(10, 50 + k * 10);
                        LD.Size = new Size(90, 13);
                        TextBox TD = new TextBox();
                        TD.Name = "textbox" + (i + 1);
                        TD.Location = new Point(110, 50 + (k * 10));
                        TD.Size = new Size(80, 13);
                        panel[i].Controls.Add(LD);
                        panel[i].Controls.Add(TD);
                        k = k + 3;
                        Button BDelete = new Button();
                        BDelete.Text = "Delete";
                        BDelete.Name = "button" + i;
                        BDelete.Location = new Point(110, 50 + (k * 10));
                        BDelete.Click += (se, ev) => {
                            MessageBox.Show("Delete");
                        };
                        BDelete.Size = new Size(100, 30);
                        panel[i].Controls.Add(BDelete);
                        break;
                    case "Read":
                        l1.Text = items[i % 4] + ' ' + NumeClasa[NumeClasa.Length - 1];
                        Label LR = new Label();
                        LR.Text = "Id";
                        LR.Location = new Point(10, 50 + k * 10);
                        LR.Size = new Size(90, 13);
                        TextBox TR = new TextBox();
                        TR.Name = "textbox" + (i + 1);
                        TR.Location = new Point(110, 50 + (k * 10));
                        TR.Size = new Size(80, 13);
                        panel[i].Controls.Add(LR);
                        panel[i].Controls.Add(TR);
                        k = k + 3;
                        Button BRead = new Button();
                        BRead.Text = "Read";
                        BRead.Name = "button" + i;
                        BRead.Location = new Point(110, 50 + (k * 10));
                        BRead.Size = new Size(100, 30);
                        BRead.Click += (se, ev) => {
                            MessageBox.Show("Read");
                        };
                        panel[i].Controls.Add(BRead);
                        Button BReadAll = new Button();
                        BReadAll.Text = "ReadAll";
                        BReadAll.Name = "button" + i;
                        BReadAll.Location = new Point(110, 50 + ((k + 3) * 10));
                        BReadAll.Size = new Size(100, 30);
                        BReadAll.Click += (se, ev) => {
                            MessageBox.Show("ReadAll");
                        };
                        panel[i].Controls.Add(BReadAll);
                        TextBox textBoxResult = new TextBox
                        {
                            Name = "",
                            Visible = true,
                            Size = new Size(200, 150),
                            Location = new Point(220, 40),
                            Multiline = true,
                            ReadOnly = true
                        };
                        panel[i].Controls.Add(textBoxResult);
                        break;

                }
                if (j < classes.Length - 1 && (i + 1) % 4 == 0)
                {
                    j++;
                }
                panel[i].Controls.Add(l1);
                Controls.Add(panel[i]);
                ListPanel.Add(panel[i]);
            }
            ListPanel.Add(ClientCreate);
            ListPanel.Add(ClientRead);
            ListPanel.Add(ClientUpdate);
            ListPanel.Add(ClientDelete);

        }

    }
}
