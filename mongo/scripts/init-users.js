// MongoDB init script for Instaconnect
// Creates application user and assigns roles across multiple databases

const appUser = process.env.MONGODB_USERNAME;
const password = process.env.MONGODB_PASSWORD;

const databases = [
  "instaconnect_identity",
  "instaconnect_posts",
  "instaconnect_chats",
  "instaconnect_follows",
];

const adminDb = db.getSiblingDB("admin");

const desiredRoles = databases.flatMap((dbName) => ([
  { role: "readWrite", db: dbName },
  { role: "dbOwner", db: dbName },
]));

const existingUser = adminDb.getUser(appUser);

if (!existingUser) {
  adminDb.createUser({
    user: appUser,
    pwd: password,
    roles: desiredRoles,
  });
} else {
  const existingRoles = existingUser.roles || [];

  const roleExists = (roleToCheck) =>
    existingRoles.some(
      (r) => r.role === roleToCheck.role && r.db === roleToCheck.db
    );

  const missingRoles = desiredRoles.filter((r) => !roleExists(r));

  if (missingRoles.length !== 0) {
    adminDb.grantRolesToUser(appUser, missingRoles);
  }
}
