namespace PaySlipService
{
    public static class TaxConstants
    {
 
        public static int TotalMonthsInOneYear = 12;

        public static double TaxIncomeTier1 = 20000;
        public static double TaxIncomeTier2 = 40000;
        public static double TaxIncomeTier3 = 80000;
        public static double TaxIncomeTier4 = 180000;

        public static double TaxRateTier1 = 0.00;
        public static double TaxRateTier2 = .1;
        public static double TaxRateTier3 = .2;
        public static double TaxRateTier4 = .3;
        public static double TaxRateAboveTier4 = .4;

        public static double TaxAmountTier1 = 0.00;
        public static double TaxAmountTier2 = 1; 
        public static double TaxAmountTier3 = 1;
        public static double TaxAmountTier4 = 1; 
        public static double TaxAmountAboveTier4 = 1;

        public const double NilTaxRate = 0.00;
        public const double InvalidTaxRate = -1.00;
    }
}
