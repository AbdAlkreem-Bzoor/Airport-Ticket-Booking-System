# Airport Ticket Booking System

## Objective
Develop a .NET console application for an airport ticket booking system. This application should enable passengers to book flight tickets and allow a manager to manage the bookings.

## Data Storage
Use the file system as the data storage layer.

## Features

### For the Passenger

- **Book a Flight:**
  - Select a flight based on various search parameters.

- **Choose a Class for the Flight:**
  - Economy, Business, First Class. Prices should vary according to the class selected.

### For the Manager

- **Filter Bookings:**
  - Parameters:
    - Price
    - Departure Country
    - Destination Country
    - Departure Date
    - Departure Airport
    - Arrival Airport
    - Flight
    - Passenger
    - Class

- **Batch Flight Upload:**
  - Import a list of flights into the system using a CSV file.

- **Validate Imported Flight Data:**
  - Apply model-level validations to the imported file data.
  - Return a detailed list of errors to help the manager identify and rectify issues in the imported file.

- **Dynamic Model Validation Details:**
  - Provide dynamically generated details about the validation constraints for each field of the flight data model.
  - **Example Result:**
    - **Departure Country:**
      - Type: Free Text
      - Constraint: Required
    - **Departure Date:**
      - Type: Date Time
      - Constraint: Required, Allowed Range (today → future)

- **Search for Available Flights:**
  - Parameters:
    - Price
    - Departure Country
    - Destination Country
    - Departure Date
    - Departure Airport
    - Arrival Airport

- **Manage Bookings:**
  - Cancel a booking
  - Modify a booking
  - View personal bookings

## How to Use

1. **Run the Application:**
   - Start the .NET console application.

2. **Passenger Actions:**
   - Use the menu options to search for flights, select a class, and book your flight.

3. **Manager Actions:**
   - Use the manager menu to upload flight data, validate imports, filter bookings, and manage existing bookings.

## System Requirements

- .NET Core SDK
- Console environment for running the application
- Access to the file system for data storage
