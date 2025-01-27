Feature: Hirist Job Application

Background: 


   Given Launch the browser
 Given User in the Hirist Home Page
	

Scenario: Apply for Jobs in Hirist Portal

	Given  User in the Hirst Job Search Page
    Then  User should see search preferences
	When User enters "<JobPreference>" and click search
    
    Then applicable jobs should display
	When user select all jobs 
	And click on Apply
	Then Jobs should be applied successfully

	Examples:
    | JobPreference |
    | Selenium Java |
    #| Specflow C#   |
    #| Automation qa |
    #| Software QA     |

	 
	
	
	
    
   
	
	