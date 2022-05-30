Feature: GetModelPriceTrend

Get historical data to be used in data grid in UI

@tag1
Scenario: [Get ModelPriceTrend data for GetModelPriceTrend for graph]
	Given [User request GetModelPriceTrend data]
	When [I send get GetModelPriceTrend data]
	Then [Data ModelPriceTrend is retreived from API]
