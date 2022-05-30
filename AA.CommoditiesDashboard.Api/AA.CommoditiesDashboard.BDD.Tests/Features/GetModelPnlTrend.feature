Feature: GetModelPnlTrend

Get historical data to be used in data grid in UI

@tag1
Scenario: [Get ModelPnlTrend data for ModelPnlTrend graph]
	Given [User request ModelPnlTrend data]
	When [I send get ModelPnlTrend data]
	Then [Data ModelPnlTrend is retreived from API]
