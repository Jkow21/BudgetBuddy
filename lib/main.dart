import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';

void main() {
  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'BudgetBuddy',
      theme: ThemeData(
        primarySwatch: Colors.blue,
      ),
      home: ExpenseListScreen(),
    );
  }
}

class ExpenseListScreen extends StatefulWidget {
  @override
  _ExpenseListScreenState createState() => _ExpenseListScreenState();
}

class _ExpenseListScreenState extends State<ExpenseListScreen> {
  List<dynamic> _expenses = [];

  @override
  void initState() {
    super.initState();
    _fetchExpenses();
  }

  Future<void> _fetchExpenses() async {
    try {
      print('🔄 Ładowanie danych z API...');
      final response = await http.get(
        Uri.parse('http://192.168.XX.XX:5165/api/Expense'), //ZMIEN ADRES IP NA SWOJ?
      );

      if (response.statusCode == 200) {
        final data = json.decode(response.body);
        print('✅ Odpowiedź z API: $data');
        setState(() {
          _expenses = data;
        });
      } else {
        print('❌ Błąd: ${response.statusCode}');
        throw Exception('Nie udało się załadować danych');
      }
    } catch (e) {
      print('❗ Wystąpił wyjątek: $e');
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Wydatki'),
      ),
      body: _expenses.isEmpty
          ? Center(child: CircularProgressIndicator())
          : ListView.builder(
              itemCount: _expenses.length,
              itemBuilder: (context, index) {
                final expense = _expenses[index];
                return ListTile(
                  title: Text(expense['name']),
                  subtitle: Text('Kwota: ${expense['amount']}'),
                );
              },
            ),
    );
  }
}
