# InstaConnect

A microservices-based social media platform for connecting and sharing content.

---

## Prerequisites

Before running the project, ensure you have the following installed:

- Docker Desktop
- Git
- Cloudinary account
- SendGrid account

---

## Running the Project

### 1. Clone the Repository

```bash
git clone https://github.com/VTUMihail1/InstaConnect.git
cd InstaConnect
```

---

### 2. Create Environment File

Create `.env` via terminal

#### PowerShell (Windows)

```powershell
@"
ADMIN_EMAIL=your_admin_email
ADMIN_PASSWORD=your_admin_password
MONGO_USERNAME=your_mongo_username
MONGO_PASSWORD=your_mongo_password
REDIS_PASSWORD=your_redis_password
RABBITMQ_USERNAME=your_rabbitmq_username
RABBITMQ_PASSWORD=your_rabbitmq_password
SEND_GRID_SENDER=your_sendgrid_sender
SEND_GRID_API_KEY=your_sendgrid_api_key
ACCESS_TOKEN_SECURITY_KEY=your_secret_key_here
CLOUDINARY_CLOUD_NAME=your_cloud_name
CLOUDINARY_API_KEY=your_api_key
CLOUDINARY_API_SECRET=your_api_secret
"@ | Out-File -FilePath .env -Encoding utf8
```

#### Bash (macOS / Linux)

```bash
cat > .env << EOF
ADMIN_EMAIL=your_admin_email
ADMIN_PASSWORD=your_admin_password
MONGO_USERNAME=your_mongo_username
MONGO_PASSWORD=your_mongo_password
REDIS_PASSWORD=your_redis_password
RABBITMQ_USERNAME=your_rabbitmq_username
RABBITMQ_PASSWORD=your_rabbitmq_password
SEND_GRID_SENDER=your_sendgrid_sender
SEND_GRID_API_KEY=your_sendgrid_api_key
ACCESS_TOKEN_SECURITY_KEY=your_secret_key_here
CLOUDINARY_CLOUD_NAME=your_cloud_name
CLOUDINARY_API_KEY=your_api_key
CLOUDINARY_API_SECRET=your_api_secret
EOF
```

---

### 3. Start the Application

```bash
docker-compose up --build
```
