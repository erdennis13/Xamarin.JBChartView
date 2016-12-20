using System;

using UIKit;
using Xamarin.JBChartView;
using Foundation;

namespace Xamarin.JBChartView.Sample
{
    public class JBChartViewController : UIViewController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;
            // Perform any additional setup after loading the view, typically from a nib.

            JBBarChartView barChartView = new JBBarChartView();
            barChartView.Frame = new CoreGraphics.CGRect(0, 0, View.Bounds.Width, View.Bounds.Height / 2);
            barChartView.DataSource = new BarChartDataSource();
            barChartView.Delegate = new BarChartDelegate();
            View.AddSubview(barChartView);

            barChartView.ReloadData();

            JBLineChartView lineChartView = new JBLineChartView();
            lineChartView.Frame = new CoreGraphics.CGRect(0, View.Bounds.Height / 2, View.Bounds.Width, View.Bounds.Height / 2);
            lineChartView.DataSource = new LineChartDataSource();
            lineChartView.Delegate = new LineChartDelegate();
            View.AddSubview(lineChartView);

            lineChartView.ReloadData();
        }

        class BarChartDataSource : JBBarChartViewDataSource
        {
            public override nuint NumberOfBarsInBarChartView(JBBarChartView barChartView)
            {
                return 5;
            }
        }

        class BarChartDelegate : JBBarChartViewDelegate
        {
            public override nfloat HeightForBarViewAtIndex(JBBarChartView barChartView, nuint index)
            {
                return index;
            }
        }

        class LineChartDataSource : JBLineChartViewDataSource
        {
            public override nuint NumberOfLinesInLineChartView(JBLineChartView lineChartView)
            {
                return 1;
            }

            public override nuint NumberOfVerticalValuesAtLineIndex(JBLineChartView lineChartView, nuint lineIndex)
            {
                return 10;
            }

            public override bool ShowsDotsForLineAtLineIndex(JBLineChartView lineChartView, nuint lineIndex)
            {
                return true;
            }

            public override bool SmoothLineAtLineIndex(JBLineChartView lineChartView, nuint lineIndex)
            {
                return true;
            }
        }

        class LineChartDelegate : JBLineChartViewDelegate
        {
            Random rnd = new Random();
            public override nfloat VerticalValueForHorizontalIndex(JBLineChartView lineChartView, nuint horizontalIndex, nuint lineIndex)
            {
                return rnd.Next(0, 10);
            }

            public override UIColor ColorForLineAtLineIndex(JBLineChartView lineChartView, nuint lineIndex)
            {
                return UIColor.Magenta;
            }

            public override UIColor FillColorForLineAtLineIndex(JBLineChartView lineChartView, nuint lineIndex)
            {
                return UIColor.Green;
            }

            public override UIColor ColorForDotAtHorizontalIndex(JBLineChartView lineChartView, nuint horizontalIndex, nuint lineIndex)
            {
                return UIColor.Gray;
            }
            public override nfloat WidthForLineAtLineIndex(JBLineChartView lineChartView, nuint lineIndex)
            {
                return 5f;
            }

            public override nfloat DotRadiusForDotAtHorizontalIndex(JBLineChartView lineChartView, nuint horizontalIndex, nuint lineIndex)
            {
                return 10f;
            }
        }
    }
}