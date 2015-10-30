using System;
using System.Collections.Generic;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Xamarin.Forms;
using OxyPlot.Annotations;
using OxyPlot.Axes;
using OxyPlot.Reporting;
using OxyPlot.Xamarin;
using Xamarin.Forms;

namespace Peni
{
	public partial class HealthHome : ContentPage
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Peni.HealthHome"/> class.
		/// </summary>
		public HealthHome ()
		{
			InitializeComponent ();
			CreateWaterGraph ();
			CreateCaloriesGraph ();
			CreateFeelingsGraph ();
		}

		/// <summary>
		/// Creates the water graph.
		/// </summary>
		private void CreateWaterGraph() {
			// Create the plot model
			var model = new PlotModel { 
				Title = "Water",
			};

			//ScatterSeries caloriesbarseries = new ScatterSeries ();
			// Create the graph type
			ColumnSeries caloriesbarseries = new ColumnSeries();

			Random rand = new Random ();

			// Populate
			for (int i = 0; i < 30; ++i) {
				ColumnItem item = new ColumnItem {
					Color = OxyColor.FromRgb(124, 219, 255),
					Value = rand.Next(2500),
				};

				caloriesbarseries.Items.Add (item);
			
			}

			// Add the graph to the plot model
			model.Series.Add (caloriesbarseries);

			// Create the view which contains the model
			PlotView view = new PlotView {
				Model = model,
				VerticalOptions = LayoutOptions.Start,
				//HorizontalOptions = LayoutOptions.Fill,
			};

			// Add the plot view to our grid
			main.Children.Add (view, 0, 0);
		}

		private void CreateCaloriesGraph() {
			// Create the plot model
			var model = new PlotModel { 
				Title = "Calories",
			};

			// Create the graph type
			ColumnSeries caloriesbarseries = new ColumnSeries();
			Random rand = new Random ();

			// Populate
			for (int i = 0; i < 30; ++i) {
				ColumnItem item = new ColumnItem {
					Color = OxyColor.FromRgb(255, 0, 0),
					Value = rand.Next(2500)
				};
				caloriesbarseries.Items.Add (item);
			}

			// Add the graph to the plot model
			model.Series.Add (caloriesbarseries);

			// Create the view which contains the model
			PlotView view = new PlotView {
				Model = model,
				VerticalOptions = LayoutOptions.Start,
				//HorizontalOptions = LayoutOptions.Fill,
			};

			// Add the plot view to our grid
			main.Children.Add (view, 0, 1);
		}

		/// <summary>
		/// Creates the feelings graph.
		/// </summary>
		private void CreateFeelingsGraph() {
			// Create the plot model
			var model = new PlotModel { 
				Title = "Feelings",
			};

			// Create the graph type (pie)
			PieSeries feelingspieview = new PieSeries {
				StrokeThickness = 2.0,
				InsideLabelPosition = 0.8,
				AngleSpan = 360,
				StartAngle = 0
			};

			feelingspieview.InsideLabelPosition = 0.0;
			feelingspieview.InsideLabelFormat = null;

			for (int i = 0; i < 3; i++)
			{
				Random rand = new Random ();
				int value = rand.Next();
				feelingspieview.Slices.Add (new PieSlice ("Happy", value));
				feelingspieview.OutsideLabelFormat = null;
			}

			model.Series.Add (feelingspieview);

			PlotView view = new PlotView {
				Model = model,
				VerticalOptions = LayoutOptions.End,
				//HorizontalOptions = LayoutOptions.Fill,
			};
			main.Children.Add (view, 0, 2);


			//Content = view; 


		}
	}
}

