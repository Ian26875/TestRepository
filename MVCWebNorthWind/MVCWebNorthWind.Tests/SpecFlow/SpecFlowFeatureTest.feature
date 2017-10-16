Feature: SpecFlowFeatureTest
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Add two numbers
	Given 商品資料
	| Leng |
	| 5    |
	When 執行計算
	Then 運算結果應該為100
