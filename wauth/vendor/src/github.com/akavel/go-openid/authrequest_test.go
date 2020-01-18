// Copyright 2010 Florian Duraffourg. All rights reserved.
// Use of this source code is governed by a BSD-style
// license that can be found in the LICENSE file.

package openid

import (
	"bytes"
	"testing"
)

// normalizeIdentifier Test

type normalizeIdentifierTest struct {
	in, out string
	t       int
}

var normalizeIdentifierTests = []normalizeIdentifierTest{
	//normalizeIdentifierTest{"example.com", "http://example.com/", identifierURL},
	//normalizeIdentifierTest{"http://example.com", "http://example.com/", identifierURL},
	normalizeIdentifierTest{"https://example.com/", "https://example.com/", identifierURL},
	normalizeIdentifierTest{"http://example.com/user", "http://example.com/user", identifierURL},
	normalizeIdentifierTest{"http://example.com/user/", "http://example.com/user/", identifierURL},
	normalizeIdentifierTest{"http://example.com/", "http://example.com/", identifierURL},
	normalizeIdentifierTest{"=example", "=example", identifierXRI},
	normalizeIdentifierTest{"xri://=example", "=example", identifierXRI},
}

func TestnormalizeIdentifier(testing *testing.T) {
	for _, nit := range normalizeIdentifierTests {
		v, t := normalizeIdentifier(nit.in)
		if !bytes.Equal([]byte(v), []byte(nit.out)) || t != nit.t {
			testing.Errorf("normalizeIdentifier(%s) = (%s, %d) want (%s, %d).", nit.in, v, t, nit.out, nit.t)
		}
	}
}

// GetRedirectURL Test

var Identifiers = []string{
	"https://www.google.com/accounts/o8/id",
	//"orange.fr",
	//"yahoo.com",
}

// Just check that there is no errors returned by GetRedirectURL
func TestGetRedirectURL(t *testing.T) {
	for _, url := range Identifiers {
		_, err := GetRedirectURL(url, "http://example.com", "/loginCheck")
		if err != nil {
			t.Errorf("GetRedirectURL() returned the error: %s\n", err.Error())
		}
	}
}
