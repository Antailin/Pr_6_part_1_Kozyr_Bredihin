# Практическая работа 6.1: Создание Автоматизированных Unit-Тестов
## Цель работы: 
Провести тестирование разработанных программных модулей с использованием средств автоматизации Microsoft Visual Studio методом
&quot;белого ящика&quot;.
## Разработчики группы 3ИСИП-123: Бредихин, Козырь.

### 1) Тесты метода Debit
1.  Debit_WithValidAmount_UpdatesBalance — проверяет, что при допустимой сумме списания баланс уменьшается корректно. Начальный баланс 11.99, списание 4.55, ожидаемый остаток 7.44. Тест выявил ошибку в исходном коде: баланс увеличивался вместо уменьшения (m_balance += amount). После исправления на m_balance -= amount тест успешно пройден.
2.  Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange — проверяет, что при сумме списания меньше нуля (-100.00) генерируется исключение ArgumentOutOfRangeException с корректным сообщением "Debit amount is less than zero". Тест пройден успешно.
3.  Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange — проверяет, что при сумме списания 20.00, превышающей баланс 11.99, генерируется исключение с сообщением "Debit amount exceeds balance". Тест пройден успешно.

### 2) Тесты метода Credit (самостоятельная часть)
1.  Credit_WithValidAmount_UpdatesBalance — проверяет корректное пополнение счёта. Начальный баланс 11.99, пополнение 5.77, ожидаемый баланс 17.76. Метод Credit реализован корректно (m_balance += amount), тест пройден успешно.
2.  Credit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange — проверяет, что при отрицательной сумме пополнения (-50.00) генерируется исключение ArgumentOutOfRangeException с сообщением "Credit amount is less than zero". Тест пройден успешно.

### Результаты работы приложения.
<img width="1280" height="337" alt="image" src="https://github.com/user-attachments/assets/399a266e-cd1d-42c1-8bc1-3b613336578e" />

### Обозреватель решений.
<img width="1280" height="369" alt="image" src="https://github.com/user-attachments/assets/7e46fb85-5f1b-48a2-adf4-989e4396a908" />

## Вывод:
В ходе выполнения практической работы были разработаны автоматизированные модульные тесты для класса BankAccount методом «белого ящика».
В процессе тестирования была обнаружена и исправлена ошибка в методе Debit: вместо вычитания суммы (m_balance -= amount) выполнялось прибавление (m_balance += amount). Именно тест Debit_WithValidAmount_UpdatesBalance выявил данную ошибку — тест завершился неудачей, поскольку фактический баланс не совпал с ожидаемым.
После исправления ошибки все 5 тестов были пройдены успешно:
1)  Debit_WithValidAmount_UpdatesBalance — ПРОЙДЕН
2)  Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange — ПРОЙДЕН
3)  Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange — ПРОЙДЕН
4)  Credit_WithValidAmount_UpdatesBalance — ПРОЙДЕН
5)  Credit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange — ПРОЙДЕН
Рефакторинг тестируемого кода позволил сделать тесты более информативными и надёжными: теперь при сбое теста точно видно, какое условие нарушено.
Таким образом, модульное тестирование подтвердило свою эффективность для раннего обнаружения ошибок и улучшения качества кода.
