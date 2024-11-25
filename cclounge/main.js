if (typeof window !=="undefined"){
let trilho = document.getElementById('trilho')
let body = document.querySelector('body')   
let background = document.getElementById('home')
let newsletter = document.getElementById('newsletter')
let footer = document.getElementById('footer')
let definicao = document.getElementById('produto')
let menuh1 = document.getElementById('h1menu')

trilho.addEventListener('click', ()=>{
    trilho.classList.toggle('dark')
    body.classList.toggle('dark')
    background.classList.toggle('dark')
    newsletter.classList.toggle('dark')
    footer.classList.toggle('dark')
    definicao.classList.toggle('dark')
    menuh1.classList.toggle('dark')
})}