
namespace Extensions
{
    public enum Power { PS, hp, kW }
    public enum Mass { kg, lb, g }
    public enum PMRatio { PS_kg, kW_kg, hp_lb }
    public enum Torque { N_m, lb_ft }

    public static class UnitExtension
    {
        private const double g = 9.80665;

        // 1 lb = 16 oz
        // 1 oz = 28.349523125 g
        // 1 kg = 1000 g
        private const double lb_to_kg = 16.0 * 28.349523125 / 1000.0;

        // 1 kW = 1000 kg * m² / s³
        // 1 PS = 75 kg * 9.80665 m / s² * 1 m / s
        private const double PS_to_kW = 75.0 * g / 1000.0;

        // 1 kW = 1000 kg * m² / s³
        // 1 ft = 2.54 mm * 12 in / 1000.0 = 0.3048
        // 1 hp = 550 ft * kg_to_lb = 550 * 0.3048 * kg_to_lb
        private const double hp_to_kW = 550.0 * 0.3048 * g * lb_to_kg / 1000.0;

        private const double ft_to_m = 0.3048;

        // 1 lb-ft = 1 lb * g * 1 ft
        // 1 N.m = 1 kg * g * 1 m
        private const double lbft_to_Nm = lb_to_kg * g * ft_to_m;

        public static double Convert_Torque(this double number, Torque from, Torque to)
        {
            if (from == to) return number;

            double number_in_Nm = 1.0;

            switch (from)
            {
                case Torque.lb_ft:
                    number_in_Nm = number * lbft_to_Nm;
                    break;
                case Torque.N_m:
                    number_in_Nm = number;
                    break;
            }

            double converted = number_in_Nm;

            switch (to)
            {
                case Torque.lb_ft:
                    converted = number_in_Nm / lbft_to_Nm;
                    break;
                case Torque.N_m:
                    converted = number_in_Nm;
                    break;
            }

            return converted;
        }

        public static double Convert_PMRatio(this double number, PMRatio from, PMRatio to)
        {
            if (from == to) return number;

            double number_in_kWkg = 1.0;

            switch (from)
            {
                case PMRatio.PS_kg:
                    number_in_kWkg = number * PS_to_kW;
                    break;
                case PMRatio.kW_kg:
                    number_in_kWkg = number;
                    break;
                case PMRatio.hp_lb:
                    number_in_kWkg = number * hp_to_kW / lb_to_kg;
                    break;
            }

            double converted = number_in_kWkg;

            switch (to)
            {
                case PMRatio.PS_kg:
                    converted = number_in_kWkg / PS_to_kW;
                    break;
                case PMRatio.kW_kg:
                    converted = number_in_kWkg;
                    break;
                case PMRatio.hp_lb:
                    converted = number_in_kWkg * lb_to_kg / hp_to_kW;
                    break;
            }

            return converted;
        }

        public static double Convert_Power(this double number, Power from, Power to)
        {
            if (from == to) return number;

            double number_in_kW = 1.0;

            switch (from)
            {
                case Power.PS:
                    number_in_kW = number * PS_to_kW;
                    break;
                case Power.hp:
                    number_in_kW = number * hp_to_kW;
                    break;
                case Power.kW:
                    number_in_kW = number;
                    break;
            }

            double converted = number_in_kW;

            switch (to)
            {
                case Power.PS:
                    converted = number_in_kW / PS_to_kW;
                    break;
                case Power.hp:
                    converted = number_in_kW / hp_to_kW;
                    break;
                case Power.kW:
                    converted = number_in_kW;
                    break;
            }

            return converted;
        }

        public static double Convert_Mass(this double number, Mass from, Mass to)
        {
            if (from == to) return number;

            double number_in_kg = 1.0;

            switch (from)
            {
                case Mass.lb:
                    number_in_kg = number * lb_to_kg;
                    break;
                case Mass.kg:
                    number_in_kg = number;
                    break;
                case Mass.g:
                    number_in_kg = number / 1000.0;
                    break;
            }

            double converted = number_in_kg;

            switch (to)
            {
                case Mass.lb:
                    converted = number_in_kg / lb_to_kg;
                    break;
                case Mass.kg:
                    converted = number_in_kg;
                    break;
                case Mass.g:
                    converted = number_in_kg * 1000.0;
                    break;
            }

            return converted;
        }
    }
}
