Feature: GetCommodityRunningPnl

Get historical data to be used in data grid in UI

@tag1
Scenario: [Get commodity data for commodity running pnl data grid]
	Given [User request commodity data]
	When [I send get commodity data]
	Then [Data commodity is retreived from API]
