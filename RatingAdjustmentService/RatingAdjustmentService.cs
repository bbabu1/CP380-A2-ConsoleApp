using System;

namespace RatingAdjustment.Services
{

    public class RatingAdjustmentService
    {
        const double MAX_STARS = 5.0;
        const double Z = 1.96; 

        double _q;
        double _percent_positive;

void SetPercentPositive(double stars)
 {

            _percent_positive = (stars * 20.0) / 100.0;

 }

void SetQ(double number_of_ratings)
        {

            double n = number_of_ratings;
            double p = _percent_positive;
            _q = Z * Math.Sqrt(((p * (1.0 - p)) + ((Z * Z) / (4.0 * n))) / n);
        }

public double Adjust(double stars, double number_of_ratings)
   {
       if (stars <= MAX_STARS)
            {
                SetPercentPositive(stars);
                SetQ(number_of_ratings);
                double n = number_of_ratings;
                double p = _percent_positive;
                double q = _q;
                double lbound = ((p + ((Z * Z) / (2.0 * n)) - q) / (1.0 + ((Z * Z) / n)));
                return (lbound / 20.0) * 100.0;
            }
      return 0.0;
}
}
}
