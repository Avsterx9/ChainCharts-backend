namespace Crypto.API.Models.Dto;

public record TokenDescriptionDto
{
    public string id { get; set; }
    public string symbol { get; set; }
    public string name { get; set; }
    public string web_slug { get; set; }
    public object asset_platform_id { get; set; }
    public int block_time_in_minutes { get; set; }
    public string hashing_algorithm { get; set; }
    public List<string> categories { get; set; }
    public bool preview_listing { get; set; }
    public object public_notice { get; set; }
    public List<object> additional_notices { get; set; }
    public DescriptionContainer description { get; set; }
    public Links links { get; set; }
    public Image image { get; set; }
    public string country_origin { get; set; }
    public string genesis_date { get; set; }
    public double sentiment_votes_up_percentage { get; set; }
    public double sentiment_votes_down_percentage { get; set; }
    public int watchlist_portfolio_users { get; set; }
    public int market_cap_rank { get; set; }
    public MarketData market_data { get; set; }
    public CommunityData community_data { get; set; }
    public DeveloperData developer_data { get; set; }
    public List<object> status_updates { get; set; }
    public DateTime last_updated { get; set; }
}

public class PriceContainer
{
    public double bch { get; set; }
    public double btc { get; set; }
    public double eth { get; set; }
    public double eur { get; set; }
    public double gbp { get; set; }
    public double jpy { get; set; }
    public double pln { get; set; }
    public double xrp { get; set; }
}

public class DateContainer
{
    public DateTime bch { get; set; }
    public DateTime btc { get; set; }
    public DateTime eth { get; set; }
    public DateTime eur { get; set; }
    public DateTime gbp { get; set; }
    public DateTime jpy { get; set; }
    public DateTime pln { get; set; }
    public DateTime xrp { get; set; }
}

public class DescriptionContainer
{
    public string en { get; set; }
    public string de { get; set; }
    public string es { get; set; }
    public string fr { get; set; }
    public string it { get; set; }
    public string pl { get; set; }
}

public class CommunityData
{
    public object facebook_likes { get; set; }
    public int twitter_followers { get; set; }
    public double reddit_average_posts_48h { get; set; }
    public double reddit_average_comments_48h { get; set; }
    public int reddit_subscribers { get; set; }
    public int reddit_accounts_active_48h { get; set; }
    public object telegram_channel_user_count { get; set; }
}

public class ConvertedLast
{
    public double btc { get; set; }
    public double eth { get; set; }
    public double usd { get; set; }
}

public class ConvertedVolume
{
    public double btc { get; set; }
    public double eth { get; set; }
    public double usd { get; set; }
}

public class DeveloperData
{
    public int forks { get; set; }
    public int stars { get; set; }
    public int subscribers { get; set; }
    public int total_issues { get; set; }
    public int closed_issues { get; set; }
    public int pull_requests_merged { get; set; }
    public int pull_request_contributors { get; set; }
    public int commit_count_4_weeks { get; set; }
}

public class Image
{
    public string thumb { get; set; }
    public string small { get; set; }
    public string large { get; set; }
}

public class Links
{
    public List<string> homepage { get; set; }
    public string whitepaper { get; set; }
    public List<string> blockchain_site { get; set; }
    public List<string> official_forum_url { get; set; }
    public List<string> chat_url { get; set; }
    public List<string> announcement_url { get; set; }
    public string telegram_channel_identifier { get; set; }
    public string subreddit_url { get; set; }
    public ReposUrl repos_url { get; set; }
}

public class Market
{
    public string name { get; set; }
    public string identifier { get; set; }
    public bool has_trading_incentive { get; set; }
}

public class MarketData
{
    public PriceContainer current_price { get; set; }
    public object total_value_locked { get; set; }
    public object mcap_to_tvl_ratio { get; set; }
    public object fdv_to_tvl_ratio { get; set; }
    public object roi { get; set; }
    public PriceContainer ath { get; set; }
    public PriceContainer ath_change_percentage { get; set; }
    public DateContainer ath_date { get; set; }
    public PriceContainer atl { get; set; }
    public PriceContainer atl_change_percentage { get; set; }
    public DateContainer atl_date { get; set; }
    public PriceContainer market_cap { get; set; }
    public int market_cap_rank { get; set; }
    public PriceContainer fully_diluted_valuation { get; set; }
    public double market_cap_fdv_ratio { get; set; }
    public PriceContainer total_volume { get; set; }
    public PriceContainer high_24h { get; set; }
    public PriceContainer low_24h { get; set; }
    public double price_change_24h { get; set; }
    public double price_change_percentage_24h { get; set; }
    public double price_change_percentage_7d { get; set; }
    public double price_change_percentage_14d { get; set; }
    public double price_change_percentage_30d { get; set; }
    public double price_change_percentage_60d { get; set; }
    public double price_change_percentage_200d { get; set; }
    public double price_change_percentage_1y { get; set; }
    public double market_cap_change_24h { get; set; }
    public double market_cap_change_percentage_24h { get; set; }
    public PriceContainer price_change_24h_in_currency { get; set; }
    public PriceContainer price_change_percentage_1h_in_currency { get; set; }
    public PriceContainer price_change_percentage_24h_in_currency { get; set; }
    public PriceContainer price_change_percentage_7d_in_currency { get; set; }
    public PriceContainer price_change_percentage_14d_in_currency { get; set; }
    public PriceContainer price_change_percentage_30d_in_currency { get; set; }
    public PriceContainer price_change_percentage_60d_in_currency { get; set; }
    public PriceContainer price_change_percentage_200d_in_currency { get; set; }
    public PriceContainer price_change_percentage_1y_in_currency { get; set; }
    public PriceContainer market_cap_change_24h_in_currency { get; set; }
    public PriceContainer market_cap_change_percentage_24h_in_currency { get; set; }
    public double total_supply { get; set; }
    public double? max_supply { get; set; }
    public double circulating_supply { get; set; }
    public DateTime last_updated { get; set; }
}

public class ReposUrl
{
    public List<string> github { get; set; }
    public List<string> bitbucket { get; set; }
}

