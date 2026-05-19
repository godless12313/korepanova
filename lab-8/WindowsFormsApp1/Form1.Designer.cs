using System;
using System.Drawing;
using System.Windows.Forms;

public class Form1 : Form
{
    private TextBox txt_F1, txt_S1, txt_S2, txt_Res3;
    private Button btn_Calc3;

    private TextBox txt_a, txt_Res12;
    private Button btn_Calc12;

    public Form1()
    {


        this.Text = "Физический калькулятор (Задачи 3 и 12)";
        this.Size = new Size(450, 380);
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;

        SetupTask3();

        SetupTask12();
    }

    private void SetupTask3()
    {
        int y = 20;
        AddLabel("Задача 3: Гидравлический пресс", new Point(20, y), 14, FontStyle.Bold);
        y += 25;

        AddLabel("F₁ (Н):", new Point(20, y));
        txt_F1 = new TextBox { Location = new Point(120, y - 2), Size = new Size(80, 20) };
        this.Controls.Add(txt_F1);

        y += 30;
        AddLabel("S₁ (м²):", new Point(20, y));
        txt_S1 = new TextBox { Location = new Point(120, y - 2), Size = new Size(80, 20) };
        this.Controls.Add(txt_S1);

        y += 30;
        AddLabel("S₂ (м²):", new Point(20, y));
        txt_S2 = new TextBox { Location = new Point(120, y - 2), Size = new Size(80, 20) };
        this.Controls.Add(txt_S2);

        y += 30;
        btn_Calc3 = new Button { Text = "Рассчитать F₂", Location = new Point(20, y), Size = new Size(120, 30) };
        btn_Calc3.Click += Btn_Calc3_Click;
        this.Controls.Add(btn_Calc3);

        y += 40;
        AddLabel("Результат F₂ (Н):", new Point(20, y));
        txt_Res3 = new TextBox { Location = new Point(140, y - 2), Size = new Size(100, 20), ReadOnly = true, BackColor = SystemColors.Window };
        this.Controls.Add(txt_Res3);
    }

    private void SetupTask12()
    {
        int y = 200;
        AddLabel("Задача 12: Архимедова сила", new Point(20, y), 14, FontStyle.Bold);
        y += 25;

        AddLabel("Ребро кубика a (см):", new Point(20, y));
        txt_a = new TextBox { Location = new Point(165, y - 2), Size = new Size(80, 20) };
        this.Controls.Add(txt_a);

        y += 30;
        btn_Calc12 = new Button { Text = "Рассчитать Fₐ", Location = new Point(20, y), Size = new Size(120, 30) };
        btn_Calc12.Click += Btn_Calc12_Click;
        this.Controls.Add(btn_Calc12);

        y += 40;
        AddLabel("Архимедова сила (Н):", new Point(20, y));
        txt_Res12 = new TextBox { Location = new Point(175, y - 2), Size = new Size(100, 20), ReadOnly = true, BackColor = SystemColors.Window };
        this.Controls.Add(txt_Res12);
    }

    private void AddLabel(string text, Point location, float size = 10, FontStyle style = FontStyle.Regular)
    {
        this.Controls.Add(new Label
        {
            Text = text,
            Location = location,
            AutoSize = true,
            Font = new Font("Microsoft Sans Serif", size, style)
        });
    }

    
    private void Btn_Calc3_Click(object sender, EventArgs e)
    {
        try
        {
            double F1 = Convert.ToDouble(txt_F1.Text);
            double S1 = Convert.ToDouble(txt_S1.Text);
            double S2 = Convert.ToDouble(txt_S2.Text);

            if (S1 == 0) throw new ArgumentException("Площадь S₁ не может быть равна 0.");

            double F2 = F1 * (S2 / S1);
            txt_Res3.Text = F2.ToString("F2");
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ошибка ввода данных:\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void Btn_Calc12_Click(object sender, EventArgs e)
    {
        try
        {
            double a_cm = Convert.ToDouble(txt_a.Text);
            double a_m = a_cm / 100.0; 

            double V = Math.Pow(a_m, 3); 

     double FA = 1000 * 10 * V;

            txt_Res12.Text = FA.ToString("F4");
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ошибка ввода данных:\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}