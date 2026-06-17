create TABLE if NOT exists funcionarios (
	id integer generated always as identity primary key,
	nome varchar(100) not null, 
	cpf varchar(11) not null,
	situacao char not null default 'A',
	data_cadastro timestamp with time zone default current_timestamp
);

create table if not exists tickets (
	id integer generated always as identity primary key,
	id_funcionario integer references funcionarios not null,
	quantidade integer not null, 
	situacao char not null default 'A', 
	data_cadastro timestamp with time zone default current_timestamp
);

