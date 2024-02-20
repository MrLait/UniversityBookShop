// @ts-nocheck
import { motion } from 'framer-motion';

const transition = (OgComponent) => {
    return () => (
        <>
            <motion.div
                initial={{ opacity: 0 }}
                animate={{ opacity: 1 }}
                exit={{ opacity: 1 }}
                transition={{ duration: 0.7 }}
            >
                <OgComponent />
            </motion.div>

        </>
    );
};
export default transition;