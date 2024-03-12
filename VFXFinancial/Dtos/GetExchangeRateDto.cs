namespace VFXFinancial.Dtos
{
    public record GetExchangeRateDto
    {
        public string FromCurrency { get; set; }

        public string ToCurrency { get; set; }

    }
}
