Feature: Reserve seats

Scenario Outline: Empty theather
	Given the film <filmName>, the showtime <showTime> and the <seatsAccount> reservation
	When reverve the seats <seats>
	Then the teather should display the seats like booked
	
	Examples: Happy path reserves
		| filmName                   | showTime | seatsAccount | seats                |
		| "El violinista del diablo" | "2"      | "3"          | "1,12;1,13;1,14"     |
