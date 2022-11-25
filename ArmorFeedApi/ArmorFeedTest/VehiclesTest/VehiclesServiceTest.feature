Feature: VehiclesServiceTest
As a developer 
	I want to register a new Enterprise
	So that It can be available for applications.
	
	Background:
		Given the Endpoint https://localhost:7017/api/v1/sign-up is available
		And A Enterprise is already stored in Enterpise's Data
		  
@mytag
Scenario: Sign up Enterprise
	When A Post Request is Sent
	  | name  | photo                                                                                                          | ruc       | phoneNumber | description | email                | paassword | priceBase | factorWeight | shippingTime | score |
	  | Italo | https://d500.epimg.net/cincodias/imagenes/2016/07/04/lifestyle/1467646262_522853_1467646344_noticia_normal.jpg | 422241242 | 916982833   | Enterprise  | enterprise@gmail.com | 123456    | 20        | 15           | 2022         | 4     |
	Then A Response with Status 200 is Recieved