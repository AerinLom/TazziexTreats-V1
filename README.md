# TazzieXTreats

TazzieXTreats is a web application built using the ASP.NET MVC framework that allows users to browse an online bakery store, add delicious baked goods to their shopping cart, and process payments securely. This project is designed to provide users with a simple and intuitive shopping experience for ordering baked treats online.

## Features

- **Browse Products**: View a wide selection of baked goods categorized for easy navigation.
- ** USer Sessions **: Once users login, their data is stored to their account.
- **Add to Cart**: Users can add items to their cart and adjust quantities before proceeding to checkout.
- **Secure Checkout**: Process payments through a secure payment gateway.
- **User Authentication**: Sign-up and log in to create and manage your user profile.

## Technologies Used

- **Frontend**: HTML, CSS, JavaScript, Bootstrap
- **Backend**: ASP.NET Core MVC, C#
- **Database**: Server of your choice
- **Payment Gateway**: Integration with Stripe for payment processing
- **IDE**: Visual Studio

## Installation and Setup

1. **Clone the repository**:
    ```bash
    git clone https://github.com/yourusername/TazzieXTreats.git
    ```

2. **Navigate to the project directory**:
    ```bash
    cd TazzieXTreats
    ```

3. **Install Dependencies**: Open the solution in Visual Studio and restore NuGet packages.

4. **Configure the database**:
    - Set up a SQL Server instance and update the `appsettings.json` file with your connection string.
    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Database=YourDB;User Id=your_username;Password=your_password;"
      }
    }
    ```

5. **Run Migrations**:
    Open the Package Manager Console and run:
    ```bash
    Update-Database
    ```

6. **Configure Payment Gateway**:
    - Set up Stripe by adding your API keys in the `appsettings.json` file.
    ```json
    {
      "PaymentSettings": {
        "StripeApiKey": "your_stripe_api_key",
        "PayPalApiKey": "your_paypal_api_key"
      }
    }
    ```

7. **Run the Application**:
    - Press F5 in Visual Studio or run the application from the command line:
    ```bash
    dotnet run
    ```

8. **Access the Application**:
    - Navigate to `http://localhost:5000` in your browser.

## Usage

- **Users**: Sign up, browse the bakery, add items to your cart, and checkout securely.

## Contributing

Contributions are welcome! Please open an issue or submit a pull request with any improvements or new features.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
