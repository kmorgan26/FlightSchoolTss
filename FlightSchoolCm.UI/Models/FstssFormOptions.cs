using FluentValidation;
using MudBlazor;

namespace FlightSchoolCm.UI.Models;

public class FstssFormOptions
{
    public string ButtonText { get; set; } = "ADD";
    
    public Variant ButtonVariant { get; set; } = Variant.Filled;

    public Color ButtonColor { get; set; } = Color.Primary;

    public Size ButtonSize { get; set; } = Size.Medium;

    public MudForm MudForm { get; set; } = null!;

    public Func<MudForm>? FormSubmit { get; set; }
}
