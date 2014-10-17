using System;

namespace GrauhundReisen.Infrastructure
{
  public static class ForString
  {
    public static bool IsNotNullOrEmpty(this string value)
    {
      return !String.IsNullOrWhiteSpace(value);
    }
  }
}