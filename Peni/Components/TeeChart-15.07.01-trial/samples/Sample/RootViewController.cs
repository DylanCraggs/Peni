using System;
using System.Drawing;

using Foundation;
using UIKit;
using Steema.TeeChart;

namespace Sample_Unified
{
    public partial class RootViewController : UIViewController
    {
        public RootViewController(IntPtr handle)
            : base(handle)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        #region View lifecycle

        TChart Chart;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
            Chart = new TChart();
            Chart.Frame = View.Frame;
            Chart.Aspect.View3D = false;
            Chart.Axes.Bottom.Grid.Visible = false;
            Chart.Axes.Bottom.MinorTicks.Visible = false;
            Chart.Axes.Left.Increment = 50;
            Chart.Axes.Left.AxisPen.Width = 1;
            Chart.Axes.Bottom.AxisPen.Width = 1;

            Chart.Legend.Transparent = true;
            Chart.Legend.Alignment = LegendAlignments.Bottom;
            Chart.Walls.Back.Visible = false;
            Chart.Panel.Gradient.Visible = false;

            Chart.Panning.Active = true;

            Steema.TeeChart.Styles.Line line1 = new Steema.TeeChart.Styles.Line(Chart.Chart);
            Steema.TeeChart.Styles.Line line2 = new Steema.TeeChart.Styles.Line(Chart.Chart);
            Steema.TeeChart.Styles.Line line3 = new Steema.TeeChart.Styles.Line(Chart.Chart);
            Steema.TeeChart.Styles.Line line4 = new Steema.TeeChart.Styles.Line(Chart.Chart);

            for (int i=0;i<4;i++)
            {
                Chart.Series[i].FillSampleValues(20);
                (Chart.Series[i] as Steema.TeeChart.Styles.Line).LinePen.Width = 3;
                (Chart.Series[i] as Steema.TeeChart.Styles.Line).Pointer.Visible = true;
                (Chart.Series[i] as Steema.TeeChart.Styles.Line).Pointer.Pen.Visible = false;
            }

            View.AddSubview(Chart);
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
        }

        #endregion
    }
}