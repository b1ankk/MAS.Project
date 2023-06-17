import { CustomContentProps, SnackbarContent } from 'notistack';
import { forwardRef } from 'react';
import Toast from 'react-bootstrap/Toast';

export const ServiceBookedSnackbar = forwardRef<HTMLDivElement, CustomContentProps>(
    (props, ref) => {
        const { id, message, style, ...other } = props;

        return (
            <SnackbarContent ref={ref} style={style}>
                <Toast className="m-1" bg="success">
                    <Toast.Body className="text-light fs-6">{message}</Toast.Body>
                </Toast>
            </SnackbarContent>
        );
    }
);

export default ServiceBookedSnackbar;
