export const Header = (props: { children: any }) => {
    return (
        <header className="p-2 flex flex-row justify-between items-center">
            {props.children}
        </header>
    )
}