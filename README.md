# 🏠 iKos – Simple Boarding House Management App

**iKos** is a mobile application built using **.NET MAUI (C#)** to help boarding house (kos) owners manage their tenants, rooms, and monthly payments. This app was developed as part of a final project (UAS) for the iOS Programming course at Politeknik Enjinering Indorama.

## ✨ Features

- 👤 **User Authentication**
  - Register & login with username, password, and boarding house name
  - Profile editing with image upload support

- 🏘️ **Room Management**
  - Add, edit, and view room details with photos
  - Mark rooms as occupied or available

- 👥 **Tenant Management**
  - Assign tenants to available rooms
  - View and manage tenant information

- 💸 **Payment Tracking**
  - Mark tenant payment status for the current month
  - View list of paid and unpaid tenants

- 📱 **Modern UI**
  - Dark theme interface
  - Navigation tab with icons
  - Smooth navigation transitions


## 🛠️ Technologies Used

- **.NET MAUI (Multi-platform App UI)**
- **C#**
- **XAML** for UI design
- **MVVM-lite architecture**
- **Local data storage using in-memory services** (`RoomService`, `AuthService`)

## 🚀 How to Run

1. Clone this repository:
   ```bash
   git clone https://github.com/your-username/iKosUASApp.git
Open the solution in Visual Studio 2022 or later with .NET MAUI workload installed.

Set target platform to Android Emulator or physical Android device.

Run the app (F5 or ▶️ Start button).

💡 This app is intended for educational/demo use only. For production, consider implementing persistent storage and user authentication backend.

📂 Project Structure
graphql
Copy
Edit
iKosUASApp/
│
├── Pages/               # All XAML pages (UI)
│   ├── HomePage.xaml
│   ├── RoomPage.xaml
│   ├── AddTenantPage.xaml
│   └── etc.
│
├── Model/               # Data models
│   ├── Room.cs
│   ├── Tenant.cs
│   └── User.cs
│
├── Service/             # In-memory service classes
│   ├── AuthService.cs
│   ├── RoomService.cs
│   └── etc.
│
├── Resources/           # Icons & images
│
└── App.xaml.cs          # App startup logic
🧪 Validation & Error Handling
✅ All forms (register, login, add room, etc.) include field validation.

🚫 Cannot register with existing username.

🚫 Cannot assign a tenant to an occupied room.

🚫 Cannot submit empty form fields.

🎓 Credits
Developed by Muhamad Rafli Kamal
For UAS iOS Programming – TRPL, Politeknik Enjinering Indorama (2025)
