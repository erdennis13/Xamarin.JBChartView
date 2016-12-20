using System;
using ObjCRuntime;

namespace Xamarin.JBChartView
{
    [Native]
    public enum JBChartViewState : ulong
    {
        Expanded,
        Collapsed
    }

    [Native]
    public enum JBLineChartViewLineStyle : ulong
    {
        Solid,
        Dashed
    }

    [Native]
    public enum JBLineChartViewColorStyle : ulong
    {
        Solid,
        Gradient
    }
}
