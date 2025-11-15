using System.Runtime.Intrinsics.X86;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

public partial class FormulaCuadraticaViewModel : ObservableObject
{
    [ObservableProperty]
    private double a; //declarar usando la primera letra minuscula

    [ObservableProperty]
    private double b;

    [ObservableProperty]
    private double c;

    [ObservableProperty]
    private double x1;

    [ObservableProperty]
    private double x2;

    [RelayCommand]
    private async Task Calcular()
    {
        FormulaCuadratica formulaCuadratica = new FormulaCuadratica(A, B, C); // Al usar la variable, la primera letra debe ser mayuscula

        if (formulaCuadratica.A == 0)
        {
            await Application.Current!.MainPage!.DisplayAlert("ADVERTENCIA", "El coeficiente 'a' no puede ser un valor cero.", "Aceptar");
        }
        else
        {
            double discriminante = Math.Pow(formulaCuadratica.B, 2) - 4 * formulaCuadratica.A * formulaCuadratica.C;

            if (discriminante >= 0)
            {
                X1 = (-formulaCuadratica.B + Math.Sqrt(discriminante)) / (2 * formulaCuadratica.A);
                X2 = (-formulaCuadratica.B - Math.Sqrt(discriminante)) / (2 * formulaCuadratica.A);
            }
            else
            {
                await Application.Current!.MainPage!.DisplayAlert("ADVERTENCIA", "No se puede calcular la raíz cuadrada con números negativos.", "");
            }
        }
    }

    [RelayCommand]
    private void Limpiar()
    {
        A = 0;
        B = 0;
        C = 0;
        X1 = 0;
        X2 = 0;
    }
}