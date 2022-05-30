Feature: GetModelRunningPnl

Get historical data to be used in data grid in UI

@tag1
Scenario: [Get ModelRunningPnl data for ModelRunningPnl data grid]
	Given [User request ModelRunningPnl data]
	When [I send get ModelRunningPnl data]
	Then [Data ModelRunningPnl is retreived from API]
