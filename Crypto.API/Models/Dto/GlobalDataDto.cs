namespace Crypto.API.Models.Dto;

public class GlobalDataDto
{
    public Data data { get; set; }
}

public class Data
{
    public int active_cryptocurrencies { get; set; }
    public int upcoming_icos { get; set; }
    public int ongoing_icos { get; set; }
    public int ended_icos { get; set; }
    public int markets { get; set; }
    public TotalMarketCap total_market_cap { get; set; }
    public TotalVolume total_volume { get; set; }
    public MarketCapPercentage market_cap_percentage { get; set; }
    public double market_cap_change_percentage_24h_usd { get; set; }
    public int updated_at { get; set; }
}

public class MarketCapPercentage
{
    public double btc { get; set; }
    public double eth { get; set; }
    public double usdt { get; set; }
    public double bnb { get; set; }
    public double sol { get; set; }
    public double usdc { get; set; }
    public double xrp { get; set; }
    public double steth { get; set; }
    public double ton { get; set; }
    public double doge { get; set; }
}

public class TotalMarketCap
{
    public double btc { get; set; }
    public double eth { get; set; }
    public double ltc { get; set; }
    public double bch { get; set; }
    public double bnb { get; set; }
    public double eos { get; set; }
    public double xrp { get; set; }
    public double xlm { get; set; }
    public double link { get; set; }
    public double dot { get; set; }
    public double yfi { get; set; }
    public double usd { get; set; }
    public double aed { get; set; }
    public double ars { get; set; }
    public double aud { get; set; }
    public double bdt { get; set; }
    public double bhd { get; set; }
    public double bmd { get; set; }
    public double brl { get; set; }
    public double cad { get; set; }
    public double chf { get; set; }
    public double clp { get; set; }
    public double cny { get; set; }
    public double czk { get; set; }
    public double dkk { get; set; }
    public double eur { get; set; }
    public double gbp { get; set; }
    public double gel { get; set; }
    public double hkd { get; set; }
    public double huf { get; set; }
    public double idr { get; set; }
    public double ils { get; set; }
    public double inr { get; set; }
    public double jpy { get; set; }
    public double krw { get; set; }
    public double kwd { get; set; }
    public double lkr { get; set; }
    public double mmk { get; set; }
    public double mxn { get; set; }
    public double myr { get; set; }
    public double ngn { get; set; }
    public double nok { get; set; }
    public double nzd { get; set; }
    public double php { get; set; }
    public double pkr { get; set; }
    public double pln { get; set; }
    public double rub { get; set; }
    public double sar { get; set; }
    public double sek { get; set; }
    public double sgd { get; set; }
    public double thb { get; set; }
    public double @try { get; set; }
    public double twd { get; set; }
    public double uah { get; set; }
    public double vef { get; set; }
    public double vnd { get; set; }
    public double zar { get; set; }
    public double xdr { get; set; }
    public double xag { get; set; }
    public double xau { get; set; }
    public double bits { get; set; }
    public double sats { get; set; }
}

public class TotalVolume
{
    public double bch { get; set; }
    public double btc { get; set; }
    public double eth { get; set; }
    public double eur { get; set; }
    public double gbp { get; set; }
    public double jpy { get; set; }
    public double pln { get; set; }
    public double xrp { get; set; }
    public double usd { get; set; }
}