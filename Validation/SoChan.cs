using System.ComponentModel.DataAnnotations;

public class SoChan : ValidationAttribute
{
  public SoChan() => ErrorMessage = "{0} phai la so chan";
  public override bool IsValid(object value)
  {
    if (value == null) return false;
    int i = int.Parse(value.ToString());
    return i % 2 == 0;
  }
}