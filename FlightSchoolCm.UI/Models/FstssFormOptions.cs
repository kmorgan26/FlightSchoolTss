using FluentValidation;
using MudBlazor;

namespace FlightSchoolCm.UI.Models;

public class FstssFormOptions<TItem> where TItem : class
{
    public string ButtonText { get; set; } = "ADD";
    
    public Variant? ButtonVariant { get; set; } = Variant.Filled;

    public Color? ButtonColor { get; set; } = Color.Primary;

    public Size? ButtonSize { get; set; } = Size.Medium;

    public TItem? FormModel { get; set; }

    public List<MudTextField<TItem>>? Fields { get; set; }

    public MudForm Form { get; set; } = null!;

    public AbstractValidator<TItem> Validator { get; set; } = null!;

    public Func<MudForm>? FormSubmit { get; set; }
}
