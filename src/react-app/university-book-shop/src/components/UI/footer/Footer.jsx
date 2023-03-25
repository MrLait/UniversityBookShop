// @ts-nocheck
import React from 'react'
import styles from './Footer.module.css'

const Footer = () => {
    return (
        <div className={styles.inner}>
            <div className={styles.footer}>
                <div className={styles.leftInner}>
                    <ul className={styles.footerNav}>
                        <li>Cookies Policy</li>
                        <li>Legal Terms</li>
                        <li>Privacy Policy</li>
                    </ul>
                </div>
                <div className={styles.rightInner}>
                    <ul className={styles.footerNav}>
                        <li><strong>Connect:</strong></li>
                        <li>Telegram</li>
                        <li>Linkedin</li>
                    </ul>
                </div>
            </div>

        </div>
    )
}

export default Footer
