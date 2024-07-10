# Sports Match Scoring - Test Instructions  (Time estimate 2-3 hours)

# Problem Description

The current code determines the winner of a sports match based on specific conditions. In this problem, we're focusing on volleyball and squash matches.

## Volleyball Match Rules
	•	A team wins if they score 15 points first, unless both teams have reached 14 points.
	•	If both teams reach 14 points, the winner is the team with a lead of two points.
	

## Squash Match Rules
	•	Best of 3 games.
	•	A team wins if they score 11 points first, unless both teams have reached 10 points.
	•	If the score in a game is tied at 10-10, a player must win by 2 clear points.

In the binary string, 0 represents TEAM 1 losing a point, and 1 represents TEAM 1 winning a point.


# Tasks

The task is to refactor the code using SOLID Principles and Design Patterns, providing unit tests to ensure the code handles the problem correctly.

## Task 1: Refactor and Extend code
Refactor the existing code using SOLID Principles and Design Patterns to handle volleyball matches with three sets and 
provide the match outcome in the format "Ravens beat Badgers (2-1) Scores: 15-7, 7-15, 15-7." 
Provide unit tests to ensure correctness.

### SOLID principles and Design Patterns
Refactor the code to adhere to SOLID principles, focusing on Single Responsibility, Open/Closed, Liskov Substitution, Interface Segregation, and Dependency Inversion principles.
Utilize appropriate design patterns such as Factory, Strategy, or Observer to enhance the structure and flexibility of the codebase.

### Logic
Ensure that the code accurately handles volleyball matches, considering the rules such as winning conditions, scoring, and determining the winner based on sets.

### Output Format
Implement the output format as specified, including the names of the competing teams, the overall match result (e.g., "Ravens beat Badgers (2-1)"), and the scores of each set.

### Unit Tests
Develop comprehensive unit tests to validate the functionality of the refactored code. Test cases should cover various scenarios.
Here is a some sample test data for the match  : "1001010101111011101111", "0110101010000100010000", "1001010101111011101111"


## Task 2: Extend sports to include Squash
Extend the current codebase to support multiple ball games. Squash will be the first game added alongside volleyball. Ensure that the code is flexible and scalable to accommodate future additions of other sports. 
Provide comprehensive unit tests for each supported sport.

### Code Extension
Modify the existing codebase to support multiple ball games, starting with Squash and retaining support for volleyball.
Implement a design that allows for easy addition of new sports in the future.

### Squash Match Logic 
Incorporate the rules for Squash matches into the codebase (Rules are mentioned above). 
Ensure that the logic accurately handles Squash matches, including scoring, determining the winner based on sets, and generating match outcomes.

### Unit Tests
Develop comprehensive unit tests to validate the functionality of the refactored code. Test cases should cover various scenarios.

## Task 3: Expand the REST API Project
Implement functionality for saving evaluated scores to a database, with each request recorded with a unique identifier (GUID). 
Ensure the API adheres to SOLID principles and design patterns. Implement the following endpoints:

Endpoints:
### Check Score and Save Result Endpoint
This endpoint receives data including the names of both teams, the score, and an input string. 
It calculates the result of the match, saves it to the database along with a unique identifier (GUID), and returns the result.

### Retrieve Historical Scores Endpoint
This endpoint retrieves historical match scores based on a provided GUID. 
It returns the details of the match stored in the database corresponding to the given identifier.

### Delete Historical Scores Endpoint
This endpoint deletes historical match scores from the database based on a provided GUID.

#### Required Data for Each Request:
- Team 1 Name
- Team 2 Name
- Score
- Input String

#### Testing and Implementation:
Ensure thorough testing of the API through a set of unit tests that connect to an in-memory database. 
Test cases should cover various scenarios to validate the functionality of each endpoint, including successful saving of scores, retrieval of historical data, and deletion of records. 
Implement SOLID principles and design patterns to ensure maintainability, scalability, and flexibility of the API codebase.


# Submission Instructions
Submit the refactored code using SOLID Principles and Design Patterns along with the unit tests for each task. 
Ensure adherence to SOLID Principles and Design Patterns with comprehensive test coverage. 
Submission should include Solution projects with code and tests.
