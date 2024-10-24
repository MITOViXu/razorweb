using Microsoft.AspNetCore.Mvc.ModelBinding;

/**
  -
*/
public class UserNameBinding : IModelBinder
{
  public Task BindModelAsync(ModelBindingContext bindingContext)
  {
    if (bindingContext == null)
    {
      throw new ArgumentException("bindingContext");
    }
    string modelName = bindingContext.ModelName;

    var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);
    if (valueProviderResult == ValueProviderResult.None) return Task.CompletedTask;
    string value = valueProviderResult.FirstValue;
    if (string.IsNullOrEmpty(value)) return Task.CompletedTask;
    //
    string s = value.ToUpper();
    if (s.Contains("XXX"))
    {
      bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);
      bindingContext.ModelState.TryAddModelError(modelName, "Lỗi do chứa XXX");
      return Task.CompletedTask;
    }
    s = s.Trim();
    bindingContext.ModelState.SetModelValue(modelName, s, s);
    bindingContext.Result = ModelBindingResult.Success(s);

    return Task.CompletedTask;

  }
}