# 🏠 iKos - Aplikasi Manajemen Kos Sederhana

**iKos** adalah aplikasi manajemen kos berbasis mobile yang dibangun menggunakan .NET MAUI. Aplikasi ini memungkinkan pemilik kos untuk mengelola data kamar, penyewa, dan status pembayaran secara efisien dan praktis.

---

## 👨‍💼 Tim Pengembang

- Muhamad Rafli Kamal
- Haidar Fatah
- Muhammad Fathy Farahat
  
  Project UAS - Mata Kuliah Pemrograman iOS
  TRPL - Politeknik Enjinering Indorama

---

## 📱 Fitur Utama

- 🔐 **Login dan Registrasi**

  - Validasi input (tidak boleh kosong)
  - Registrasi dengan nama kosan

- 🏘 **Manajemen Kamar**

  - Tambah, lihat, edit, hapus kamar
  - Upload gambar kamar
  - Status kamar tersedia atau terisi

- 👥 **Manajemen Penyewa**

  - Tambah penyewa dan pasangkan dengan kamar yang tersedia
  - Lihat data penyewa dan detailnya

- 💸 **Status Pembayaran**

  - Kelompokkan penyewa berdasarkan status lunas/belum lunas bulan ini
  - Akses detail pembayaran penyewa

- 📸 **Profil Kos**

  - Ubah nama kosan dan foto profil

---

## 🧠 Teknologi yang Digunakan

- .NET MAUI (Multi-platform App UI)
- Bahasa: C#
- Struktur MVVM sederhana
- Penyimpanan data lokal (non-database)

---

## 📀 Struktur Folder

```
iKosUASApp/
│
├── Pages/               # All XAML pages (UI)
│   ├── HomePage.xaml
│   ├── RoomPage.xaml
│   ├── TenantPage.xaml
│   └── etc.
│
├── Model/               # Data models
│   ├── Room.cs
│   ├── Tenant.cs
│   ├── Payment.cs
│   ├── TenantViewModel.cs
│   └── User.cs
│
├── Service/             # In-memory service classes
│   ├── AuthService.cs
│   ├── RoomService.cs
│   └── DataService.cs
│
├── Resources/           # Icons & images
│
└── App.xaml.cs          # App startup logic

```

---

## 🧐 Konsep Pemrograman yang Digunakan

### ✅ Class & Object

Semua entitas utama diatur dengan class:

```csharp
public class Room {
    public string RoomNumber { get; set; }
    public string? Description { get; set; }
    public Tenant? Tenant { get; set; }
}
```

### ✅ Inheritance

Setiap halaman mewarisi dari `ContentPage`, contoh:

```csharp
public partial class HomePage : ContentPage
```

### ✅ Array & Dictionary

Digunakan untuk menyimpan dan memproses data:

```csharp
List<Room> rooms = RoomService.GetRooms();
Dictionary<string, User> users = new();
```

### ✅ Layout & Komponen UI

- `StackLayout`, `ScrollView`, `Grid`, `Frame`
- Komponen: `Label`, `Entry`, `Button`, `Picker`, `Image`, `CollectionView`, dll.
- Desain dengan **dark mode** (`#191919`) dan aksen warna putih/abu.

---

## 🖼️ Tampilan Aplikasi

| Halaman          | Tampilan                           |
| ---------------- | ---------------------------------- |
| Login / Register | Input form, navigasi               |
| Dashboard        | Ikon & statistik sederhana         |
| Kamar            | Daftar kamar, status, gambar       |
| Penyewa          | Daftar penyewa dan kamar terkait   |
| Pembayaran       | Status lunas/belum lunas per bulan |
| Profile          | Edit Profile, LogOut |

---


