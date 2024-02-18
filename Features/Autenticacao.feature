# language: pt

Funcionalidade: Autenticação
	Sendo um usuãrio cadastrado
	Pode informar seus dados de autenticação
	Para acessar o sistema

Contexto: 
	Dado que o usuário acessa o sistema "https://www.saucedemo.com/"

Regra: Deve ser possível informar dados de autenticação para acessar o sistema

Cenário: Autenticação: Ao acessar o sistema o usuário poderáa informar seus dados e solicitar acesso ao sistema
	Quando solicita para realizar o login informando seus dados de autenticação
		| Campo    | Valor         |
		| Username | standard_user |
		| Password | secret_sauce  |
	Então acessa o sistema "Swag Labs"