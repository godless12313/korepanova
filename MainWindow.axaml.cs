using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace lab_1_avalonia;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        // Привязываем обработчики кнопок
        btn_Calc3.Click += Btn_Calc3_Click;
        btn_Calc12.Click += Btn_Calc12_Click;
    }

    // ══ Задача 3: Гидравлический пресс ══════════════════════════
    // Формула: F2 = F1 * (S2 / S1)  — закон Паскаля
    private void Btn_Calc3_Click(object? sender, RoutedEventArgs e)
    {
        txt_Error.Text = "";
        txt_Res3.Text = "";
        try
        {
            // Читаем данные из полей, заменяем точку на запятую для парсинга
            double F1 = double.Parse(txt_F1.Text!.Replace('.', ','));
            double S1 = double.Parse(txt_S1.Text!.Replace('.', ','));
            double S2 = double.Parse(txt_S2.Text!.Replace('.', ','));

            if (S1 <= 0) throw new Exception("S₁ должна быть больше нуля.");
            if (F1 < 0 || S2 < 0) throw new Exception("Значения не могут быть отрицательными.");

            // Расчёт силы на большом поршне
            double F2 = F1 * (S2 / S1);

            txt_Res3.Text = F2.ToString("F2");
        }
        catch (Exception ex)
        {
            txt_Error.Text = "Ошибка (Задача 3): " + ex.Message;
        }
    }

    // ══ Задача 12: Архимедова сила ══════════════════════════════
    // Формула: Fа = ρ * g * V,  где V = a³  (a переводим из см в м)
    private void Btn_Calc12_Click(object? sender, RoutedEventArgs e)
    {
        txt_Error.Text = "";
        txt_Res12.Text = "";
        try
        {
            // Читаем ребро кубика в сантиметрах
            double a_cm = double.Parse(txt_a.Text!.Replace('.', ','));

            if (a_cm <= 0) throw new Exception("Ребро должно быть больше нуля.");

            double a_m = a_cm / 100.0;       // переводим в метры
            double V = Math.Pow(a_m, 3);   // объём кубика V = a³

            double rho = 1000.0;  // плотность воды, кг/м³
            double g = 10.0;    // ускорение свободного падения, м/с²

            double FA = rho * g * V;          // архимедова сила

            txt_Res12.Text = FA.ToString("F6");
        }
        catch (Exception ex)
        {
            txt_Error.Text = "Ошибка (Задача 12): " + ex.Message;
        }
    }
}