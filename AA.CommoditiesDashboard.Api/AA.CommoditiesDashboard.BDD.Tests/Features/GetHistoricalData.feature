Feature: GetHistoricalData

Get historical data to be used in data grid in UI

@tag1
Scenario: [Get historical data for historical data grid]
	Given [User request historical data]
	When [I send get hisotrical data]
	Then [Data is retreived from API]
