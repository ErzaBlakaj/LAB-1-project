CREATE TABLE feedback (
  id INT PRIMARY KEY AUTO_INCREMENT,
  user_id INT NOT NULL,
  feedback_text VARCHAR(1000) NOT NULL,
  timestamp TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  CONSTRAINT fk_user
    FOREIGN KEY (user_id)
    REFERENCES users(id)
);
INSERT INTO feedback (user_id, feedback_text) VALUES 
(1, 'This is a great app!'),
(2, 'I had some trouble with the login process.'),
(3, 'The app could use more features.');

INSERT INTO feedback (user_id, feedback_text, timestamp)
VALUES (2, 'The app crashed on me!', '2022-03-15 14:25:00');

INSERT INTO feedback (user_id, feedback_text, timestamp)
VALUES (3, 'I think the app is great!', NULL);

INSERT INTO feedback (user_id, feedback_text)
VALUES (1, 'hi ');

CREATE TABLE promocodes (
  id INT PRIMARY KEY AUTO_INCREMENT,
  code VARCHAR(20) UNIQUE NOT NULL,
  discount FLOAT NOT NULL,
  expiration_date DATE NOT NULL,
  max_usage INT DEFAULT NULL,
  usage_count INT DEFAULT 0
);
INSERT INTO promocodes (code, discount, expiration_date, max_usage)
VALUES ('FALL2023', 0.20, '2023-11-30', NULL);

CREATE TABLE notifications (
  id INT PRIMARY KEY AUTO_INCREMENT,
  user_id INT NOT NULL,
  message VARCHAR(1000) NOT NULL,
  is_read BOOLEAN DEFAULT FALSE,
  timestamp TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  CONSTRAINT fk_user
    FOREIGN KEY (user_id)
    REFERENCES users(id)
);
INSERT INTO notifications (user_id, message)
VALUES (1, 'Your order has been shipped!');

INSERT INTO notifications (user_id, message, timestamp)
VALUES (2, 'Your payment has been received!', '2023-04-12 10:30:00');

INSERT INTO notifications (user_id, message, is_read)
VALUES (3, 'Your subscription has been renewed!', TRUE);

INSERT INTO notifications (user_id, message)
VALUES 
  (4, 'Your order has been received!'),
  (4, 'Your order is being prepared.'),
  (4, 'Your order has been shipped!');

CREATE TABLE payments (
  id INT PRIMARY KEY AUTO_INCREMENT,
  user_id INT NOT NULL,
  amount DECIMAL(10, 2) NOT NULL,
  payment_date DATE NOT NULL,
  payment_method VARCHAR(20) NOT NULL,
  transaction_id VARCHAR(50) NOT NULL,
  CONSTRAINT fk_user
    FOREIGN KEY (user_id)
    REFERENCES users(id)
);
INSERT INTO payments (user_id, amount, payment_date, payment_method, transaction_id)
VALUES 
  (1, 50.00, '2023-04-12', 'PayPal', 'XYZ7890'),
  (2, 75.00, '2023-04-11', 'Credit Card', 'EFGH5678'),
  (3, 120.00, '2023-04-10', 'Bank Transfer', 'IJKL9012');

CREATE TABLE reports_and_complaints (
  id INT PRIMARY KEY AUTO_INCREMENT,
  user_id INT NOT NULL,
  subject VARCHAR(100) NOT NULL,
  message TEXT NOT NULL,
  is_resolved BOOLEAN DEFAULT FALSE,
  timestamp TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  CONSTRAINT fk_user
    FOREIGN KEY (user_id)
    REFERENCES users(id)
);
INSERT INTO reports_and_complaints (user_id, subject, message)
VALUES (1, 'Issue with account login', 'I am unable to log in to my account even after multiple attempts. Please help.');

INSERT INTO reports_and_complaints (user_id, subject, message, is_resolved)
VALUES (2, 'Fraudulent activity on my account', 'I noticed some unauthorized transactions on my account. However, I have already resolved the issue with my bank. Please ignore this report.', TRUE);

INSERT INTO reports_and_complaints (user_id, subject, message, timestamp)
VALUES (1, 'Missing order', 'I placed an order a week ago but it has not arrived yet. Can you please check the status of my order?', '2023-04-10 10:30:00');

CREATE TABLE information (
  id INT PRIMARY KEY AUTO_INCREMENT,
  title VARCHAR(100) NOT NULL,
  content TEXT NOT NULL,
  timestamp TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);
INSERT INTO information (title, content)
VALUES ('Important announcement', 'We are excited to announce that we are expanding our product line to include new categories. Stay tuned for more details!');

INSERT INTO information (title, content, timestamp)
VALUES ('Holiday hours', 'Please note that our stores will be closed on April 15th in observance of the national holiday.', '2023-04-12 12:00:00');