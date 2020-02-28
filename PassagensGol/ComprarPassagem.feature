#language: pt-br

Funcionalidade: CompraPassagem
    Como um cliente da Gol
    Eu quero acessar o site
    Para comprar duas passagens


Cenário: Comprar passagem
    Dado que o usuário acessa a página https://www.voegol.com.br/pt
    Quando o usuário seleciona a origem e destino
        E o usuário informa as datas de ida e volta
        E o usuário informa a quantidade de passageiros
    Então o sistema retorna as passagems dispon[iveis
    Quando o usuário seleciona as duas passagens
    Então o sistema calcula os valores e direciona para a tela de pagamento 
