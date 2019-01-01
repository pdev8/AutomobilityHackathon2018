# Preparing for development

* Clone the entire directory either using SSH key or Gitlab Authentication
* Run the following commands once you have received the full project (make sure  you are in the correct directory)
 - For API: dotnet restore --ignore-failed-sources 
 - For SPA: npm install

 # Install GM developer dependencies
 * Navigate to https://developer.gm.com/docs/emu-downloads (sign up for a developer account if you haven't)
    - Download the following:
        * Developer Package
        * Emulator (appropriate Mac or Windows version)
    - Install the developer package:
        * npm install -g <PATH_TO_INSTALL_PACKAGE> 

 # Starting up the application
 * Navigate into the API or SPA folder and run the appropriate command:
    - For API: dotnet run
    - For SPA: ngi serve

 # Contribution workflow

 * Development is to be completed using a feature slice approach. Each card on the Trello board represents a feature front-to-back. 
 * Claim a card from the On-Deck column and move it into In-Progress
 * Pull latest from 'dev'
 * Create a new branch specific to that Card
 * Once a feature is completed move the card to 'Ready For Review' and create a pull request to the dev branch
 * All project members are responsible for reviewing cards within the 'Ready For Review' stage
    - Claim cards in this stage and manually review the code changes in the pull request. BE STRICT
    - Features fail QA if any of the following are present:
        * Console logs
        * Needless comments
        * Not using canonical theming conventions
        * Plus obvious code issues (build errors, poor implementation, etc)
    - If a card fails QA move it back to In Development and place a Red 'Failed QA' tag on the card
    - If a card passes QA approve the pull request and move the card into the 'Approved' column
* Approved requests will be merged into dev and later into master in 'mini releases' mocking a real live release cycle

# User flow
1. Profile selection
2. Input address + duration of parking (so we don't send you to 30 min parking if you need to be there for longer)
3. Navigation screen
	* TWO PARTS: (left = map view; B. right = step-by-step collapsible directions + filter icons)
	* once you're within #x mile radius, view will change to indicate areas of parking availability
	* green = currently available
	* yellow = available soon
	* red = not available
4. once you're in the spot, then view switches to parking payment (same as phone app)
	* this is how often we'll pay for you (intervals)
	* per interval, this is how much it'll cost
	* and max time at that spot is #x hours
	* and option to stop payments
Additional Things.
	* profile creation
	* profile settings

# What happens if someone already took the spot?
* We can predict to the closest possibility over historical data + opening data stream with constant data once you're in x-mile radius
* It'll show green until they pay (small overlap right before they snaked in front of you, but same as IRL)
* We're providing a much higher chance of getting the spot instead of just circling

# Not relevant to look at live data when we're 40 mins away. So we look PRIMARILY at historical data.
	
* When the user puts in the destination, we're not going to drive them to the front door of the destination (e.g. Staples Center)
	* Amend their route destination (prediction model)
	* Then once they're nearby, then we're switching over to live data
	* Staples Center will be nuts going in and and going out; cheaper and more efficient if we parallel park

# Two case study users
1. He doesn't mind all these things, so we'll send him to the heart of it
2. She's more than happy to find a bird for the last stretch; historically chosen this option

# Are we including structures? Or only meters?
* Only publicly available data