# 📚 Stationery Management System - ASP.NET MVC

This is a role-based web application developed using ASP.NET MVC for efficiently managing stationery item requests within an organization. The system automates the request, approval, and inventory tracking process, with email notifications integrated via SMTP.

## 🔑 Roles in the System

1. **Admin**
   - View all requests
   - Approve/Reject item requests
   - Manage inventory

2. **Manager**
   - Submit item requests
   - Track request status
   - View past request history

3. **Assistant Manager**
   - Same permissions as Manager
   - Additional tracking and assistance features

4. **User/Employee**
   - Submit stationery item requests
   - Receive email on request approval or rejection

---

## ✨ Key Features

- 🔐 **Authentication & Role Management**
- 📩 **SMTP Email Notifications** for request approvals & rejections
- 🔄 **Forget Password with OTP verification via Email**
- 📦 **Stationery Request Management**
- 🧾 **Request Status Tracking**
- 🧑‍💻 User-friendly dashboards for each role
- 🗃️ View and manage inventory (Admin only)

---

## 🧭 How to Use (User Guide)

### 🔐 Login
1. Enter your email and password.
2. Based on your role, you'll be redirected to your respective dashboard.

### 📝 Request Stationery (Manager/Assistant Manager/User)
1. Navigate to the Request section.
2. Fill out the form with item details and submit.
3. Wait for Admin’s approval via email.

### ✅ Admin Actions
1. Go to the request list.
2. Accept or reject any pending request.
3. An automatic email will be sent to the requester.

### 🛠 Forget Password Flow
1. On the Login Page, click **"Forgot Password?"**
2. Enter your registered email.
3. An OTP will be sent via email.
4. Enter the OTP and set a new password.

---
