package util

import (
	"encoding/hex"
	"crypto/sha256"
)

/* use only this function */
func MainHashHexify(password string) string {
	hash := sha256.Sum256([]byte(password))
	return hex.EncodeToString(hash[:])
}